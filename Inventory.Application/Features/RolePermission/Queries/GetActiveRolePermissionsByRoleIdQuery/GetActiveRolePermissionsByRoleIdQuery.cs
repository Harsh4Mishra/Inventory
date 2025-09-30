using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByRoleIdQuery
{
    public sealed record GetActiveRolePermissionsByRoleIdQuery : IRequest<IEnumerable<GetActiveRolePermissionsByRoleIdQueryResult>>
    {
        #region Properties
        public Guid RoleId { get; init; }
        #endregion
    }
}
