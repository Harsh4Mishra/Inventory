using MediatR;

namespace Inventory.Application.Features.Permission.Queries.GetPermissionsByTenantIdQuery
{
    public sealed record GetPermissionsByTenantIdQuery : IRequest<IEnumerable<GetPermissionsByTenantIdQueryResult>>
    {
        #region Properties
        public Guid TenantId { get; init; }
        #endregion
    }
}
