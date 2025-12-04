using MediatR;

namespace Inventory.Application.Features.EnumValue.Queries.GetActiveEnumValuesByEnumTypeIdQuery
{
    public sealed record GetActiveEnumValuesByEnumTypeIdQuery
         : IRequest<IEnumerable<GetActiveEnumValuesByEnumTypeIdQueryResult>>
    {
        #region Properties

        public int EnumTypeId { get; init; } = default;

        #endregion
    }
}
