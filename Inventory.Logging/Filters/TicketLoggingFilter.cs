
using Inventory.Logging.Interfaces;
using Inventory.Logging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace Inventory.Logging.Filters
{
    public class TicketLoggingFilter : IAsyncActionFilter
    {
        private readonly ILogWriter _logWriter;
        private readonly ILogRepository _logRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TicketLoggingFilter(ILogWriter logWriter, ILogRepository logRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logWriter = logWriter;
            _logRepository = logRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ticketId = Guid.NewGuid();
            context.HttpContext.Items["TicketId"] = ticketId;
            var requestPath = context.HttpContext.Request.Path;
            var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? "";
            var ticket = new Ticket
            {
                Id = ticketId,
                CreatedAt = DateTime.Now,
                UserId = userName,
                RequestPath = requestPath
            };

            await _logRepository.SaveTicketAsync(ticket);

            _logWriter.WriteLog(LogLevels.Info, "Request started", $"{context.HttpContext.Request.Method} {requestPath}");

            context.HttpContext.Items["TicketId"] = ticketId;

            var resultContext = await next();

            _logWriter.WriteLog(LogLevels.Info, "Request completed", $"Status code: {resultContext.HttpContext.Response.StatusCode}");
        }
    }
}
