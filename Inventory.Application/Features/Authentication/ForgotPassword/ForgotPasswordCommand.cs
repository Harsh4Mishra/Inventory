using MediatR;

namespace Inventory.Application.Features.Authentication.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<ForgotPasswordCommandDTO>
    {
        public string EmailId { get; set; } = string.Empty;
    }
}
