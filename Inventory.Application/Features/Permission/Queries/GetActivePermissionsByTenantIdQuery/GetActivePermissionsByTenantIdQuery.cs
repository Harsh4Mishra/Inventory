using MediatR;

namespace Inventory.Application.Features.Permission.Queries.GetActivePermissionsByTenantIdQuery
{
    public sealed record GetActivePermissionsByTenantIdQuery : IRequest<IEnumerable<GetActivePermissionsByTenantIdQueryResult>>
    {
        #region Properties
        public Guid TenantId { get; init; }
        #endregion
    }
}
