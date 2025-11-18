using AutoMapper;
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Logging.Interfaces;
using Inventory.Logging.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Authentication.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAesService _aesOperation;
        private readonly IConfiguration _configuration;
        private readonly ILogWriter _logWriter;

        #endregion

        #region Ctor

        public ResetPasswordCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, IAesService aesOperation, IConfiguration configuration, ILogWriter logWriter)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository;
            _aesOperation = aesOperation;
            _configuration = configuration;
            _logWriter = logWriter;
        }

        #endregion

        #region methods

        public async Task<ResetPasswordCommandDTO> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logWriter.WriteLog(LogLevels.Info, $"Reset password attempt started for Manager Email: {request.EmailId}");

                var employeeList = (await _userRepository.GetByEmailToMutateAsync(request.EmailId, cancellationToken));
                if (employeeList != null)
                {
                    var hashKey = employeeList.PasswordHashKey;
                    var saltKey = employeeList.PasswordSaltKey;
                    var oldashKey = await _aesOperation.EncryptString(saltKey, request.OldPassword);

                    var newHashKey = await _aesOperation.EncryptString(saltKey, request.NewPassword);
                    if (oldashKey == hashKey)
                    {
                        if (newHashKey != oldashKey)
                        {
                            var chipperText = await _aesOperation.GenerateRandomKey();
                            var newUpdatedHashKey = await _aesOperation.EncryptString(chipperText, request.NewPassword);

                            employeeList.UpdatePassword(newUpdatedHashKey, chipperText, request.EmailId);

                            await _unitOfWork.SaveChangesAsync(cancellationToken);

                            _logWriter.WriteLog(LogLevels.Info, $"Password reset successful for Manager Email: {request.EmailId}");

                            ResetPasswordCommandDTO resetPasswordCommandDTO = new ResetPasswordCommandDTO();
                            resetPasswordCommandDTO.IsPasswordSet = true;
                            return resetPasswordCommandDTO;

                        }
                        else
                        {
                            _logWriter.WriteLog(LogLevels.Warning, $"New password matches old password for Manager Email: {request.EmailId}");

                            throw new Exception("New Password should not be same as Old Password");
                        }
                    }
                    else
                    {
                        _logWriter.WriteLog(LogLevels.Warning, $"Invalid old password provided for Manager Email: {request.EmailId}");

                        throw new Exception("Please provide valid Old Password");
                    }
                }
                else
                {
                    _logWriter.WriteLog(LogLevels.Error, $"No manager found with Email: {request.EmailId}");
                    throw new Exception("No such Employee Found. Please provide proper Employee Code");
                }
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog(LogLevels.Error, $"Exception during password reset for Manager Email: {request.EmailId} - {ex.Message}", ex.StackTrace);
                throw ex;
            }
            finally
            {

            }
        }

        #endregion
    }
}
