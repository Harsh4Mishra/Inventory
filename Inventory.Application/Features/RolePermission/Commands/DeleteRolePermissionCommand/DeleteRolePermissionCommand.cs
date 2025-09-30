using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.DeleteRolePermissionCommand
{
    public class DeleteRolePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }

        #endregion
    }
}
