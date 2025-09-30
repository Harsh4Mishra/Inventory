using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetAllRolePermissionsQuery
{
    public sealed record GetAllRolePermissionsQuery : IRequest<IEnumerable<GetAllRolePermissionsQueryResult>>
    {
    }
}
