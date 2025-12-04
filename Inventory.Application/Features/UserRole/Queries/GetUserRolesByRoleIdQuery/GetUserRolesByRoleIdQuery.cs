using MediatR;

namespace Inventory.Application.Features.UserRole.Queries.GetUserRolesByRoleIdQuery
{
    public sealed record GetUserRolesByRoleIdQuery : IRequest<IEnumerable<GetUserRolesByRoleIdQueryResult>>
    {
        #region Properties
        public int RoleId { get; init; }
        #endregion
    }
}
