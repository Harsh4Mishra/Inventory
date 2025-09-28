using MediatR;

namespace Inventory.Application.Features.User.Queries.GetActiveUsersQuery
{
    public sealed record GetActiveUsersQuery : IRequest<IEnumerable<GetActiveUsersQueryResult>>
    {
        // No parameters needed for this query
    }
}
