
namespace Inventory.Application.Features.UserRole.Queries.GetUserRolesByRoleIdQuery
{
    public sealed record GetUserRolesByRoleIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid RoleId { get; init; }
        public string UserName { get; init; } = default!; // You might want to include user name for better UX
        public string UserEmail { get; init; } = default!; // You might want to include user email
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
