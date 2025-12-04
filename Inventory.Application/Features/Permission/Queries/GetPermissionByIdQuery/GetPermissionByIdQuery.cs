using MediatR;

namespace Inventory.Application.Features.Permission.Queries.GetPermissionByIdQuery
{
    public sealed record GetPermissionByIdQuery : IRequest<GetPermissionByIdQueryResult?>
    {
        #region Properties
        public int Id { get; init; }
        #endregion
    }
}
