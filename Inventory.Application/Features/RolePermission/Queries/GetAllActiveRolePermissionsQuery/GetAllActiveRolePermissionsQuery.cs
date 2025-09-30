using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetAllActiveRolePermissionsQuery
{
    public sealed record GetAllActiveRolePermissionsQuery : IRequest<IEnumerable<GetAllActiveRolePermissionsQueryResult>>
    {
    }
}
