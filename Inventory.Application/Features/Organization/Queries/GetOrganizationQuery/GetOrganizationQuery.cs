using MediatR;

namespace Inventory.Application.Features.Organization.Queries.GetOrganizationQuery
{
    public sealed record GetOrganizationQuery
         : IRequest<IEnumerable<GetOrganizationQueryResult>>
    {
    }
}
