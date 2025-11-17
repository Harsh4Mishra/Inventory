using MediatR;

namespace Inventory.Application.Features.Authentication.Login
{
    public class LoginCommand : IRequest<LoginCommandDTO>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
