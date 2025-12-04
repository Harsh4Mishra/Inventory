

namespace Inventory.Application.Features.RolePermission.Queries.GetAllActiveRolePermissionsQuery
{
    public sealed record GetAllActiveRolePermissionsQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int RoleId { get; init; }
        public string RoleName { get; init; } = default!;
        public int ModuleId { get; init; }
        public string ModuleName { get; init; } = default!;
        public int PermissionId { get; init; }
        public string PermissionName { get; init; } = default!;
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
