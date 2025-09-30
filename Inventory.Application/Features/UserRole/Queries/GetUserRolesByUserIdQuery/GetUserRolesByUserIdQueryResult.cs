

namespace Inventory.Application.Features.UserRole.Queries.GetUserRolesByUserIdQuery
{
    public sealed record GetUserRolesByUserIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid RoleId { get; init; }
        public string RoleName { get; init; } = default!; // You might want to include role name for better UX
        public string RoleCode { get; init; } = default!; // You might want to include role code
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
