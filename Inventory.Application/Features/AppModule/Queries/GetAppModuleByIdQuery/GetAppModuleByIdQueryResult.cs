

namespace Inventory.Application.Features.AppModule.Queries.GetAppModuleByIdQuery
{
    public sealed record GetAppModuleByIdQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int TenantId { get; init; }
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
