
namespace Inventory.Application.Features.EnumValue.Queries.GetEnumValuesByEnumTypeIdQuery
{
    public class GetEnumValuesByEnumTypeIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; } = default;
        public Guid EnumTypeId { get; init; } = default;
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
        public string Description { get; init; } = default!;
        public bool IsActive { get; init; } = default;
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; } = default;
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
