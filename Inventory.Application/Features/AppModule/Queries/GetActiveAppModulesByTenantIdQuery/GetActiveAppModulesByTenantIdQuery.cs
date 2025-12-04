using MediatR;

namespace Inventory.Application.Features.AppModule.Queries.GetActiveAppModulesByTenantIdQuery
{
    public sealed record GetActiveAppModulesByTenantIdQuery : IRequest<IEnumerable<GetActiveAppModulesByTenantIdQueryResult>>
    {
        #region Properties
        public int TenantId { get; init; }
        #endregion
    }
}
