

namespace Inventory.Application.Features.Organization.Queries.GetOrganizationQuery
{
    public sealed record GetOrganizationQueryResult
    {
        #region Properties

        public int Id { get; init; } = default;
        public string Name { get; init; } = default!;
        public string? Code { get; init; }
        public string? Description { get; init; }
        public bool IsActive { get; init; } = true;
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; } = default;
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }
        public DateTime? DeletedOn { get; init; }
        public string? DeletedBy { get; init; }

        #endregion
    }
}
