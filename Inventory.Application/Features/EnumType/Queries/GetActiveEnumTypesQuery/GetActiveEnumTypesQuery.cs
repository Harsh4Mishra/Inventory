using MediatR;

namespace Inventory.Application.Features.EnumType.Queries.GetActiveEnumTypesQuery
{
    public sealed record GetActiveEnumTypesQuery
         : IRequest<IEnumerable<GetActiveEnumTypesQueryResult>>
    {
    }
}
