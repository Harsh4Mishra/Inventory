using AutoMapper;
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Logging.Interfaces;
using Inventory.Logging.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Inventory.Application.Features.Authentication.SetPassword
{
    public class SetPasswordCommandHandler : IRequestHandler<SetPasswordCommand, SetPasswordCommandDTO>
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

        public SetPasswordCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, IAesService aesOperation, IConfiguration configuration, ILogWriter logWriter)
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

        public async Task<SetPasswordCommandDTO> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {

            try
            {
                _logWriter.WriteLog(LogLevels.Info, $"Set password process initiated for Manager Email: {request.EmailID}");

                var employeeList = (await _userRepository.GetByEmailToMutateAsync(request.EmailID, cancellationToken));
                if (employeeList != null)
                {
                    var chipperText = await _aesOperation.GenerateRandomKey();
                    var UpdatedHashKey = await _aesOperation.EncryptString(chipperText, request.Password);


                    employeeList.UpdatePassword(UpdatedHashKey, chipperText, request.EmailID);

                    await _unitOfWork.SaveChangesAsync(cancellationToken);

                        _logWriter.WriteLog(LogLevels.Info, $"Password successfully set for Manager Email: {request.EmailID}");
                        SetPasswordCommandDTO setPasswordCommandDTO = new SetPasswordCommandDTO();
                        setPasswordCommandDTO.IsPasswordSet = true;
                        return setPasswordCommandDTO;
                   
                }
                else
                {
                    _logWriter.WriteLog(LogLevels.Error, $"No manager found with Email: {request.EmailID}");
                    throw new Exception("No such Employee Found. Please provide proper Employee Code");
                }
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog(LogLevels.Error, $"Exception while setting password for Manager Email: {request.EmailID} - {ex.Message}", ex.StackTrace);
                throw ex;
            }
            finally
            {

            }
        }

        #endregion
    }
}
