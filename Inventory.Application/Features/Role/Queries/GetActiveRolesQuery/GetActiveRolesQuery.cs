using MediatR;

namespace Inventory.Application.Features.Role.Queries.GetActiveRolesQuery
{
    public sealed record GetActiveRolesQuery : IRequest<IEnumerable<GetActiveRolesQueryResult>>
    {
    }
}
