using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class RolePermissionRepository : IRolePermissionRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public RolePermissionRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all role-permission assignments: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.RolePermissions
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all role-permission assignments: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active role-permission assignments: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.RolePermissions
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active role-permission assignments: {ex.Message}");
            }
        }

        public async Task<RolePermissionDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignment by id: {ex.Message}");
            }
        }

        public async Task<RolePermissionDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.RolePermissions
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignment by id: {ex.Message}");
            }
        }

        public async Task<RolePermissionDO?> GetActiveByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active role-permission assignment by id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.RoleId == roleId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignments by role id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetByRoleIdToMutateAsync(
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id provided");
                }

                return await _dbContext.RolePermissions
                    .Where(e => e.RoleId == roleId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignments by role id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.RoleId == roleId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active role-permission assignments by role id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetByModuleIdAsync(
            Guid moduleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (moduleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid module id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.ModuleId == moduleId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignments by module id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetByModuleIdToMutateAsync(
            Guid moduleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (moduleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid module id provided");
                }

                return await _dbContext.RolePermissions
                    .Where(e => e.ModuleId == moduleId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignments by module id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByModuleIdAsync(
            Guid moduleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (moduleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid module id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.ModuleId == moduleId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active role-permission assignments by module id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetByPermissionIdAsync(
            Guid permissionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (permissionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid permission id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.PermissionId == permissionId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignments by permission id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetByPermissionIdToMutateAsync(
            Guid permissionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (permissionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid permission id provided");
                }

                return await _dbContext.RolePermissions
                    .Where(e => e.PermissionId == permissionId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignments by permission id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByPermissionIdAsync(
            Guid permissionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (permissionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid permission id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.PermissionId == permissionId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active role-permission assignments by permission id: {ex.Message}");
            }
        }

        public async Task<RolePermissionDO?> GetByRoleModuleAndPermissionAsync(
            Guid roleId,
            Guid moduleId,
            Guid permissionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty || moduleId == Guid.Empty || permissionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id, module id, or permission id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.RoleId == roleId && e.ModuleId == moduleId && e.PermissionId == permissionId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignment by role, module, and permission: {ex.Message}");
            }
        }

        public async Task<RolePermissionDO?> GetByRoleModuleAndPermissionToMutateAsync(
            Guid roleId,
            Guid moduleId,
            Guid permissionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty || moduleId == Guid.Empty || permissionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id, module id, or permission id provided");
                }

                return await _dbContext.RolePermissions
                    .FirstOrDefaultAsync(e => e.RoleId == roleId && e.ModuleId == moduleId && e.PermissionId == permissionId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role-permission assignment by role, module, and permission: {ex.Message}");
            }
        }

        public async Task<RolePermissionDO?> GetActiveByRoleModuleAndPermissionAsync(
            Guid roleId,
            Guid moduleId,
            Guid permissionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty || moduleId == Guid.Empty || permissionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id, module id, or permission id provided");
                }

                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.RoleId == roleId && e.ModuleId == moduleId && e.PermissionId == permissionId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active role-permission assignment by role, module, and permission: {ex.Message}");
            }
        }

        public void Add(RolePermissionDO rolePermission)
        {
            if (rolePermission is null)
            {
                throw new ArgumentNullException(nameof(rolePermission));
            }

            _dbContext.RolePermissions.Add(rolePermission);
        }

        public void Update(RolePermissionDO rolePermission)
        {
            if (rolePermission is null)
            {
                throw new ArgumentNullException(nameof(rolePermission));
            }

            _dbContext.RolePermissions.Update(rolePermission);
        }

        public void Remove(RolePermissionDO rolePermission)
        {
            if (rolePermission is null)
            {
                throw new ArgumentException(nameof(rolePermission));
            }

            _dbContext.RolePermissions.Remove(rolePermission);
        }

        public async Task<bool> ExistsByRoleModuleAndPermissionAsync(
            Guid roleId,
            Guid moduleId,
            Guid permissionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty || moduleId == Guid.Empty || permissionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id, module id, or permission id provided");
                }

                return await _dbContext.RolePermissions.AnyAsync(
                    e => e.RoleId == roleId && e.ModuleId == moduleId && e.PermissionId == permissionId,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking role-permission assignment by role, module, and permission: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByRoleModuleAndPermissionAsync(
            Guid roleId,
            Guid moduleId,
            Guid permissionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty || moduleId == Guid.Empty || permissionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id, module id, or permission id provided");
                }

                return await _dbContext.RolePermissions.AnyAsync(
                    e => e.RoleId == roleId && e.ModuleId == moduleId && e.PermissionId == permissionId && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active role-permission assignment by role, module, and permission: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.RolePermissions.AnyAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking role-permission assignment by id: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.RolePermissions.AnyAsync(
                    e => e.Id == id && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active role-permission assignment by id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByTenantIdAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                // This requires a join with AppModuleDO to filter by tenant
                // Implementation depends on your navigation property setup
                return await _dbContext.RolePermissions
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    //.Include(e => e.Module) // Need navigation property
                    //.Where(e => e.Module.TenantId == tenantId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active role-permission assignments by tenant id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RolePermissionDO>> GetActiveByTenantIdToMutateAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                // This requires a join with AppModuleDO to filter by tenant
                // Implementation depends on your navigation property setup
                return await _dbContext.RolePermissions
                    .Where(e => e.IsActive)
                    //.Include(e => e.Module) // Need navigation property
                    //.Where(e => e.Module.TenantId == tenantId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active role-permission assignments by tenant id: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByTenantIdAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                // This requires a join with AppModuleDO to filter by tenant
                // Implementation depends on your navigation property setup
                return await _dbContext.RolePermissions
                    .Where(e => e.IsActive)
                    //.Include(e => e.Module) // Need navigation property
                    //.AnyAsync(e => e.Module.TenantId == tenantId, cancellationToken);
                    .AnyAsync(cancellationToken); // Temporary implementation
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active role-permission assignments by tenant id: {ex.Message}");
            }
        }

        #endregion
    }
}
