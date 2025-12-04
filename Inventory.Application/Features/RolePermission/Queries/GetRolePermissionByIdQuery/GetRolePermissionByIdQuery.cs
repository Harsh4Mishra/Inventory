using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetRolePermissionByIdQuery
{
    public sealed record GetRolePermissionByIdQuery : IRequest<GetRolePermissionByIdQueryResult?>
    {
        #region Properties
        public int Id { get; init; }
        #endregion
    }
}
