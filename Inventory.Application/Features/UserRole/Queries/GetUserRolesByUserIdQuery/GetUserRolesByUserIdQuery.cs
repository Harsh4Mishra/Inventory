using MediatR;

namespace Inventory.Application.Features.UserRole.Queries.GetUserRolesByUserIdQuery
{
    public sealed record GetUserRolesByUserIdQuery : IRequest<IEnumerable<GetUserRolesByUserIdQueryResult>>
    {
        #region Properties
        public Guid UserId { get; init; }
        #endregion
    }
}
