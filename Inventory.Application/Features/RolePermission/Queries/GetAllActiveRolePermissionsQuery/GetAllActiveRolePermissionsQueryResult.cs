

namespace Inventory.Application.Features.RolePermission.Queries.GetAllActiveRolePermissionsQuery
{
    public sealed record GetAllActiveRolePermissionsQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid RoleId { get; init; }
        public string RoleName { get; init; } = default!;
        public Guid ModuleId { get; init; }
        public string ModuleName { get; init; } = default!;
        public Guid PermissionId { get; init; }
        public string PermissionName { get; init; } = default!;
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
