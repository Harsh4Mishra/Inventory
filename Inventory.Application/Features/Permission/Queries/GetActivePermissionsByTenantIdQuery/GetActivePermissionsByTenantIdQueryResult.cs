

namespace Inventory.Application.Features.Permission.Queries.GetActivePermissionsByTenantIdQuery
{
    public sealed record GetActivePermissionsByTenantIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid TenantId { get; init; }
        public string Code { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string? Description { get; init; }
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
