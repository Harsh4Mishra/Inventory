using MediatR;

namespace Inventory.Application.Features.Authentication.ResetPassword
{
    public class ResetPasswordCommand : IRequest<ResetPasswordCommandDTO>
    {
        #region properties

        public string EmailId { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;

        #endregion
    }
}
