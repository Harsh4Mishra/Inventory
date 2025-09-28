using MediatR;

namespace Inventory.Application.Features.User.Queries.GetUsersQuery
{
    public sealed record GetUsersQuery : IRequest<IEnumerable<GetUsersQueryResult>>
    {
        // No parameters needed for this query
    }
}
