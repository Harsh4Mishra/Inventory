using MediatR;

namespace Inventory.Application.Features.EnumValue.Queries.GetEnumValuesByEnumTypeIdQuery
{
    public sealed record GetEnumValuesByEnumTypeIdQuery
         : IRequest<IEnumerable<GetEnumValuesByEnumTypeIdQueryResult>>
    {
        #region Properties

        public int EnumTypeId { get; init; } = default;

        #endregion
    }
}
