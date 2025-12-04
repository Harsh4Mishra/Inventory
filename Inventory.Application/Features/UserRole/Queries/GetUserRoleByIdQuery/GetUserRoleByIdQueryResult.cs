

namespace Inventory.Application.Features.UserRole.Queries.GetUserRoleByIdQuery
{
    public sealed record GetUserRoleByIdQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int UserId { get; init; }
        public int RoleId { get; init; }
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
