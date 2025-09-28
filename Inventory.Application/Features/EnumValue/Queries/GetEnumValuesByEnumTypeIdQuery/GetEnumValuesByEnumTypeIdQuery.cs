using MediatR;

namespace Inventory.Application.Features.EnumValue.Queries.GetEnumValuesByEnumTypeIdQuery
{
    public sealed record GetEnumValuesByEnumTypeIdQuery
         : IRequest<IEnumerable<GetEnumValuesByEnumTypeIdQueryResult>>
    {
        #region Properties

        public Guid EnumTypeId { get; init; } = default;

        #endregion
    }
}
