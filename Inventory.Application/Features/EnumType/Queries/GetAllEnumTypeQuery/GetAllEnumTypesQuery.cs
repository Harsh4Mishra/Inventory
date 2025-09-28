using MediatR;

namespace Inventory.Application.Features.EnumType.Queries.GetAllEnumTypeQuery
{
    public sealed record GetAllEnumTypesQuery
         : IRequest<IEnumerable<GetAllEnumTypesQueryResult>>
    {
    }
}
