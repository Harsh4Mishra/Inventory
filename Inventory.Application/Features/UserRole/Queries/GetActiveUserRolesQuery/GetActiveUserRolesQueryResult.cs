
namespace Inventory.Application.Features.UserRole.Queries.GetActiveUserRolesQuery
{
    public sealed record GetActiveUserRolesQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid RoleId { get; init; }
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
