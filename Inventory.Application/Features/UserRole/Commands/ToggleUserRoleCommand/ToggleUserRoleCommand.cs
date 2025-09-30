using MediatR;

namespace Inventory.Application.Features.UserRole.Commands.ToggleUserRoleCommand
{
    public class ToggleUserRoleCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
