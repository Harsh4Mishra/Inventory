using MediatR;

namespace Inventory.Application.Features.UserRole.Queries.GetActiveUserRolesQuery
{
    public sealed record GetActiveUserRolesQuery : IRequest<IEnumerable<GetActiveUserRolesQueryResult>>
    {
    }
}
