using MediatR;

namespace Inventory.Application.Features.Organization.Queries.GetActiveOrganizationQuery
{
    public sealed record GetActiveOrganizationQuery
         : IRequest<IEnumerable<GetActiveOrganizationQueryResult>>
    {
    }
}
