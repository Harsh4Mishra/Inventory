using MediatR;

namespace Inventory.Application.Features.EnumValue.Queries.GetActiveEnumValuesByEnumTypeIdQuery
{
    public sealed record GetActiveEnumValuesByEnumTypeIdQuery
         : IRequest<IEnumerable<GetActiveEnumValuesByEnumTypeIdQueryResult>>
    {
        #region Properties

        public Guid EnumTypeId { get; init; } = default;

        #endregion
    }
}
