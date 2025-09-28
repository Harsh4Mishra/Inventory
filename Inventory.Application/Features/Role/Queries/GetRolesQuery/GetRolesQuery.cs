using MediatR;

namespace Inventory.Application.Features.Role.Queries.GetRolesQuery
{
    public sealed record GetRolesQuery : IRequest<IEnumerable<GetRolesQueryResult>>
    {
    }
}
