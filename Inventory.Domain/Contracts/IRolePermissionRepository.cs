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

        Task<RolePermissionDO?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<RolePermissionDO?> GetByIdToMutateAsync(Guid id, CancellationToken cancellationToken = default);
        Task<RolePermissionDO?> GetActiveByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<RolePermissionDO>> GetByRoleIdAsync(Guid roleId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetByRoleIdToMutateAsync(Guid roleId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByRoleIdAsync(Guid roleId, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<RolePermissionDO>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetByModuleIdToMutateAsync(Guid moduleId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<RolePermissionDO>> GetByPermissionIdAsync(Guid permissionId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetByPermissionIdToMutateAsync(Guid permissionId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByPermissionIdAsync(Guid permissionId, CancellationToken cancellationToken = default);

        Task<RolePermissionDO?> GetByRoleModuleAndPermissionAsync(Guid roleId, Guid moduleId, Guid permissionId, CancellationToken cancellationToken = default);
        Task<RolePermissionDO?> GetByRoleModuleAndPermissionToMutateAsync(Guid roleId, Guid moduleId, Guid permissionId, CancellationToken cancellationToken = default);
        Task<RolePermissionDO?> GetActiveByRoleModuleAndPermissionAsync(Guid roleId, Guid moduleId, Guid permissionId, CancellationToken cancellationToken = default);

        void Add(RolePermissionDO rolePermission);
        void Update(RolePermissionDO rolePermission);
        void Remove(RolePermissionDO rolePermission);

        Task<bool> ExistsByRoleModuleAndPermissionAsync(Guid roleId, Guid moduleId, Guid permissionId, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByRoleModuleAndPermissionAsync(Guid roleId, Guid moduleId, Guid permissionId, CancellationToken cancellationToken = default);
        Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active role-permission assignments by tenant ID
        /// </summary>
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByTenantIdAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active role-permission assignments by tenant ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByTenantIdToMutateAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active role-permission assignment exists with the given tenant ID
        /// </summary>
        Task<bool> ActiveExistsByTenantIdAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
