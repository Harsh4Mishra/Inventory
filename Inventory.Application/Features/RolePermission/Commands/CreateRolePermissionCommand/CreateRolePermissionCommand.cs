using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.CreateRolePermissionCommand
{
    public sealed record CreateRolePermissionCommand : IRequest<int>
    {
        #region Properties
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int PermissionId { get; set; }
        #endregion
    }
}
