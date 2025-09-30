using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.UpdateRolePermissionCommand
{
    public class UpdateRolePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public Guid PermissionId { get; set; }

        #endregion
    }
}
