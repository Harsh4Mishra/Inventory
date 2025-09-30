using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByTenantIdQuery
{
    public sealed record GetActiveRolePermissionsByTenantIdQuery : IRequest<IEnumerable<GetActiveRolePermissionsByTenantIdQueryResult>>
    {
        #region Properties
        public Guid TenantId { get; init; }
        #endregion
    }
}
