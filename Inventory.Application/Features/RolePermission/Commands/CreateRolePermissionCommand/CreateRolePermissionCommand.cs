using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.CreateRolePermissionCommand
{
    public sealed record CreateRolePermissionCommand : IRequest<Guid>
    {
        #region Properties
        public Guid RoleId { get; set; }
        public Guid ModuleId { get; set; }
        public Guid PermissionId { get; set; }
        #endregion
    }
}
