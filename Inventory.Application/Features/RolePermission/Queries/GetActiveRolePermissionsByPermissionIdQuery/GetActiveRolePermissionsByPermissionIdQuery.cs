using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByPermissionIdQuery
{
    public sealed record GetActiveRolePermissionsByPermissionIdQuery : IRequest<IEnumerable<GetActiveRolePermissionsByPermissionIdQueryResult>>
    {
        #region Properties
        public Guid PermissionId { get; init; }
        #endregion
    }
}
