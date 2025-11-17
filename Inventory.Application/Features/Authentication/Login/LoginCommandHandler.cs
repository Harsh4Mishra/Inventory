using AutoMapper;
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.Logging.Interfaces;
using Inventory.Logging.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Inventory.Application.Features.Authentication.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAesService _aesOperation;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly ILogWriter _logWriter;

        #endregion

        #region Ctor

        public LoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, IAesService aesOperation, IConfiguration configuration, IAuthService authService, ILogWriter logWriter)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository;
            _aesOperation = aesOperation;
            _configuration = configuration;
            _authService = authService;
            _logWriter = logWriter;
        }

        #endregion

        #region methods

        public async Task<LoginCommandDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            try
            {
                _logWriter.WriteLog(LogLevels.Info, $"Manager login attempt started for Username: {request.UserName}");

                var managerList = (await _userRepository.GetByEmailToMutateAsync(request.UserName, cancellationToken));
                if (managerList != null)
                {
                    if (managerList.NumberOfAttempts <= 5)
                    {
                        var hashKey = managerList.PasswordHashKey;
                        var saltKey = managerList.PasswordSaltKey;
                        var UpdatedHashKey = await _aesOperation.EncryptString(saltKey, request.Password);
                        if (UpdatedHashKey == hashKey)
                        {
                            LoginCommandDTO loginDetails = new LoginCommandDTO();
                            loginDetails.Name = managerList.Name;
                            loginDetails.EmailId = managerList.EmailId.EmailId;
                            loginDetails.PhoneNo = managerList.PhoneNo.PhoneNo;
                            loginDetails.EmployeeID = managerList.Id;
                            //loginDetails.IsAdmin = managerList.IsAdmin;
                            //loginDetails.OrganizationID = employeeList.OrganizationID;

                            loginDetails.JWTToken = CreateToken(managerList);
                            _logWriter.WriteLog(LogLevels.Info, $"Manager login successful for Username: {request.UserName}");

                            return loginDetails;
                        }
                        else
                        {

                            int numberOfAttempts = managerList.NumberOfAttempts;
                            numberOfAttempts = numberOfAttempts + 1;

                            managerList.UpdateNumberOfAttempts(numberOfAttempts, "System");

                            await _unitOfWork.SaveChangesAsync(cancellationToken);

                            _logWriter.WriteLog(LogLevels.Warning, $"Invalid password attempt {managerList.NumberOfAttempts} for Username: {request.UserName}");

                            throw new Exception("Invalid Credentials!");
                        }
                    }
                    else
                    {
                        _logWriter.WriteLog(LogLevels.Error, $"Password attempts exceeded for Username: {request.UserName}");

                        throw new Exception("Attempts limit has exceeded please set new credential by clicking on forgot password.");
                    }
                }
                else
                {
                    _logWriter.WriteLog(LogLevels.Error, $"No manager found with Username: {request.UserName}");

                    throw new Exception("No such Employee Found. Please provide proper Employee Code");
                }
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog(LogLevels.Error, $"Exception during manager login for Username: {request.UserName} - {ex.Message}", ex.StackTrace);

                throw ex;
            }
            finally
            {

            }
        }

        public string CreateToken(UserDO employee)
        {
            var claims = new Claim[]
            {
            new(JwtRegisteredClaimNames.Name,employee.Name),
            new(JwtRegisteredClaimNames.Sid,employee.Id.ToString()),
            new(JwtRegisteredClaimNames.Email,employee.EmailId.EmailId),
            new(JwtRegisteredClaimNames.PhoneNumber,employee.PhoneNo.PhoneNo),
            new(JwtRegisteredClaimNames.NameId,employee.Id.ToString()),
            };

            string tokenValue = _authService.GenerateToken(claims);

            return tokenValue;
        }


        #endregion
    }
}
