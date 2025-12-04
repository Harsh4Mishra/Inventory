using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.DeleteRolePermissionCommand
{
    public class DeleteRolePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }

        #endregion
    }
}
