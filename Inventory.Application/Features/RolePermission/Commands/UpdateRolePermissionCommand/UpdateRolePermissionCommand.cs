using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.UpdateRolePermissionCommand
{
    public class UpdateRolePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int PermissionId { get; set; }

        #endregion
    }
}
