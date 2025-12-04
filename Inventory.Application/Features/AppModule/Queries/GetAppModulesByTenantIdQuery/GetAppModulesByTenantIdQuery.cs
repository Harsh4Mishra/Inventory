using MediatR;

namespace Inventory.Application.Features.AppModule.Queries.GetAppModulesByTenantIdQuery
{
    public sealed record GetAppModulesByTenantIdQuery : IRequest<IEnumerable<GetAppModulesByTenantIdQueryResult>>
    {
        #region Properties
        public int TenantId { get; init; }
        #endregion
    }
}
