using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetRolePermissionByIdQuery
{
    public sealed record GetRolePermissionByIdQuery : IRequest<GetRolePermissionByIdQueryResult?>
    {
        #region Properties
        public Guid Id { get; init; }
        #endregion
    }
}
