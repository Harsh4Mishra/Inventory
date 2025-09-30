using MediatR;

namespace Inventory.Application.Features.Permission.Queries.GetPermissionByIdQuery
{
    public sealed record GetPermissionByIdQuery : IRequest<GetPermissionByIdQueryResult?>
    {
        #region Properties
        public Guid Id { get; init; }
        #endregion
    }
}
