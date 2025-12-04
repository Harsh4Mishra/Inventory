using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IRolePermissionRepository
    {
        #region Signatures

        Task<IReadOnlyCollection<RolePermissionDO>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        Task<RolePermissionDO?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<RolePermissionDO?> GetByIdToMutateAsync(int id, CancellationToken cancellationToken = default);
        Task<RolePermissionDO?> GetActiveByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<RolePermissionDO>> GetByRoleIdAsync(int roleId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetByRoleIdToMutateAsync(int roleId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByRoleIdAsync(int roleId, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<RolePermissionDO>> GetByModuleIdAsync(int moduleId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetByModuleIdToMutateAsync(int moduleId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByModuleIdAsync(int moduleId, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<RolePermissionDO>> GetByPermissionIdAsync(int permissionId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetByPermissionIdToMutateAsync(int permissionId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByPermissionIdAsync(int permissionId, CancellationToken cancellationToken = default);

        Task<RolePermissionDO?> GetByRoleModuleAndPermissionAsync(int roleId, int moduleId, int permissionId, CancellationToken cancellationToken = default);
        Task<RolePermissionDO?> GetByRoleModuleAndPermissionToMutateAsync(int roleId, int moduleId, int permissionId, CancellationToken cancellationToken = default);
        Task<RolePermissionDO?> GetActiveByRoleModuleAndPermissionAsync(int roleId, int moduleId, int permissionId, CancellationToken cancellationToken = default);

        void Add(RolePermissionDO rolePermission);
        void Update(RolePermissionDO rolePermission);
        void Remove(RolePermissionDO rolePermission);

        Task<bool> ExistsByRoleModuleAndPermissionAsync(int roleId, int moduleId, int permissionId, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByRoleModuleAndPermissionAsync(int roleId, int moduleId, int permissionId, CancellationToken cancellationToken = default);
        Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active role-permission assignments by tenant ID
        /// </summary>
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByTenantIdAsync(
            int tenantId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active role-permission assignments by tenant ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByTenantIdToMutateAsync(
            int tenantId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active role-permission assignment exists with the given tenant ID
        /// </summary>
        Task<bool> ActiveExistsByTenantIdAsync(
            int tenantId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
