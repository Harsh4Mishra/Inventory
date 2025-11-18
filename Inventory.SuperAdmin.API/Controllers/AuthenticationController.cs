using Inventory.Application.Features.Authentication.ForgotPassword;
using Inventory.Application.Features.Authentication.Login;
using Inventory.Application.Features.Authentication.ResetPassword;
using Inventory.Application.Features.Authentication.SetPassword;
using Inventory.Logging.Filters;
using Inventory.Logging.Interfaces;
using Inventory.Logging.Models;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(TicketLoggingFilter))]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogWriter _logWriter;

        public AuthenticationController(IMediator mediator, ILogWriter logWriter)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logWriter = logWriter;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            try
            {
                _logWriter.WriteLog(LogLevels.Info, "Requested for Login");

                // Delegate login logic to MediatR handler
                var loginDetails = await _mediator.Send(request);

                var successApiResponse = new SuccessAPIResponse<LoginCommandDTO>(loginDetails, true, "Login Done Successfully", 200);
                _logWriter.WriteLog(LogLevels.Info, "Login done Successfully");
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog(LogLevels.Error, ex.Message, ex.StackTrace.ToString());
                throw ex;
            }
        }

        [HttpPost("SetPassword")]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordCommand request)
        {
            try
            {
                _logWriter.WriteLog(LogLevels.Info, "Requested to set Password");

                var result = await _mediator.Send(request);

                var successApiResponse = new SuccessAPIResponse<SetPasswordCommandDTO>(result, true, "Password Set Successfully", 200);
                _logWriter.WriteLog(LogLevels.Info, "Password Set Successfully");
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog(LogLevels.Error, ex.Message, ex.StackTrace.ToString());
                throw ex;
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand request)
        {
            try
            {
                _logWriter.WriteLog(LogLevels.Info, "Requested for forgot Password");
                var result = await _mediator.Send(request);

                var successApiResponse = new SuccessAPIResponse<ForgotPasswordCommandDTO>(result, true, "Link has been sent on the registered Email ID.", 200);
                _logWriter.WriteLog(LogLevels.Info, "Link has been sent on the registered Email ID.");
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog(LogLevels.Error, ex.Message, ex.StackTrace.ToString());
                throw ex;
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand request)
        {
            try
            {
                _logWriter.WriteLog(LogLevels.Info, "Requested to reset Password");
                var result = await _mediator.Send(request);

                var successApiResponse = new SuccessAPIResponse<ResetPasswordCommandDTO>(result, true, "Password Updated Successfully", 200);
                _logWriter.WriteLog(LogLevels.Info, "Password Updated Successfully");
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog(LogLevels.Error, ex.Message, ex.StackTrace.ToString());
                throw ex;
            }
        }
    }
}
