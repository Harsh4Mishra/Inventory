using MediatR;

namespace Inventory.Application.Features.Authentication.SetPassword
{
    public class SetPasswordCommand : IRequest<SetPasswordCommandDTO>
    {
        #region properties

        public string EmailID { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        #endregion
    }
}
