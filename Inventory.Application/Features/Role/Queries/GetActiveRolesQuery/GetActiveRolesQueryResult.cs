namespace Inventory.Application.Features.Role.Queries.GetActiveRolesQuery
{
    public sealed record GetActiveRolesQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
        public string? Description { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
