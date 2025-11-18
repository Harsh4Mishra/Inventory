using AutoMapper;
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Authentication.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAesService _aesOperation;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        private readonly IUTFService _uTFService;

        #endregion

        #region Ctor

        public ForgotPasswordCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, IAesService aesOperation, IConfiguration configuration, IMailService mailService, IUTFService uTFService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository;
            _aesOperation = aesOperation;
            _configuration = configuration;
            _mailService = mailService;
            _uTFService = uTFService;
        }

        #endregion

        #region methods

        public async Task<ForgotPasswordCommandDTO> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var employeeList = (await _userRepository.GetByEmailToMutateAsync(request.EmailId, cancellationToken));
                if (employeeList != null)
                {
                    employeeList.ResetAttempts(request.EmailId);

                    await _unitOfWork.SaveChangesAsync(cancellationToken);

                    var UpdatedHashKey = _uTFService.Encryptdata(request.EmailId);


                    string baseURL = _configuration["WebRedirectURL:RedirectURL"].ToString();
                    string passwordPageName = _configuration["WebRedirectURL:SetPasswordPage"].ToString();
                    string setPasswordURL = baseURL + passwordPageName + UpdatedHashKey;

                    string subject = "Reset Your Account Password...";
                    string body = MailBody(employeeList.Name, setPasswordURL);
                    string emailid = employeeList.EmailId.EmailId;
                    _mailService.SendMail(subject, body, emailid);

                    ForgotPasswordCommandDTO forgotPasswordCommandDTO = new ForgotPasswordCommandDTO();
                    forgotPasswordCommandDTO.IsPasswordSet = true;

                    return forgotPasswordCommandDTO;
                }
                else
                {
                    throw new Exception("No such Manager Found. Please provide proper Manager Email");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public string MailBody(string employeeName, string url)
        {
            return $@"
                     <!DOCTYPE html>
                     <html>
                     <head>
                         <style>
                             body {{
                                 font-family: Arial, sans-serif;
                                 line-height: 1.6;
                             }}
                             .container {{
                                 max-width: 600px;
                                 margin: 0 auto;
                                 padding: 20px;
                                 border: 1px solid #ddd;
                                 border-radius: 5px;
                                 background-color: #f9f9f9;
                             }}
                             .header {{
                                 text-align: center;
                                 border-bottom: 1px solid #ddd;
                                 margin-bottom: 20px;
                                 padding-bottom: 10px;
                             }}
                             .content {{
                                 text-align: left;
                             }}
                             .footer {{
                                 text-align: center;
                                 margin-top: 20px;
                                 font-size: 0.9em;
                                 color: #777;
                             }}
                         </style>
                     </head>
                     <body>
                         <div class='container'>
                             <div class='header'>
                                 <h2>Password Reset Request</h2>
                             </div>
                             <div class='content'>
                                 <p>Dear {employeeName},</p>
                                 <p>We received a request to reset your password. Please click the link below to reset your password:</p>
                                 <p><a href='{url}'>Click here</a> to set your new password</p>
                                 <p>If you did not request a password reset, please ignore this email or contact support if you have questions.</p>
                                 <p>Best regards,<br/>The Support Team</p>
                             </div>
                             <div class='footer'>
                                 <p>© {DateTime.Now.Year} AIUT. All rights reserved.</p>
                             </div>
                         </div>
                     </body>
                     </html>";
        }

        #endregion
    }
}
