using Inventory.Application.Features.Authentication.Login;
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
    }
}
