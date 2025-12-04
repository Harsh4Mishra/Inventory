using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.ToggleRolePermissionCommand
{
    public class ToggleRolePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
