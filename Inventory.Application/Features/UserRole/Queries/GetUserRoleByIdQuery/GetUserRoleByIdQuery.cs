using MediatR;

namespace Inventory.Application.Features.UserRole.Queries.GetUserRoleByIdQuery
{
    public sealed record GetUserRoleByIdQuery : IRequest<GetUserRoleByIdQueryResult?>
    {
        #region Properties
        public int Id { get; init; }
        #endregion
    }
}
