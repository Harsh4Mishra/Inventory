using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class PermissionRepository : IPermissionRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public PermissionRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<PermissionDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Permissions
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all permissions: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<PermissionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Permissions
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all permissions: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<PermissionDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Permissions
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active permissions: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<PermissionDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Permissions
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active permissions: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Permissions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching permission by id: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Permissions
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching permission by id: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetActiveByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Permissions
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active permission by id: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid code provided");
                }

                return await _dbContext.Permissions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching permission by code: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetByCodeToMutateAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid code provided");
                }

                return await _dbContext.Permissions
                    .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching permission by code: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetActiveByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid code provided");
                }

                return await _dbContext.Permissions
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active permission by code: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<PermissionDO>> GetByTenantIdAsync(
            int tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                return await _dbContext.Permissions
                    .AsNoTracking()
                    .Where(e => e.TenantId == tenantId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching permissions by tenant id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<PermissionDO>> GetByTenantIdToMutateAsync(
            int tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                return await _dbContext.Permissions
                    .Where(e => e.TenantId == tenantId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching permissions by tenant id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<PermissionDO>> GetActiveByTenantIdAsync(
            int tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                return await _dbContext.Permissions
                    .AsNoTracking()
                    .Where(e => e.TenantId == tenantId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active permissions by tenant id: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetByTenantAndCodeAsync(
            int tenantId,
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0 || string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid tenant id or code provided");
                }

                return await _dbContext.Permissions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.TenantId == tenantId && e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching permission by tenant and code: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetByTenantAndCodeToMutateAsync(
            int tenantId,
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0 || string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid tenant id or code provided");
                }

                return await _dbContext.Permissions
                    .FirstOrDefaultAsync(e => e.TenantId == tenantId && e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching permission by tenant and code: {ex.Message}");
            }
        }

        public async Task<PermissionDO?> GetActiveByTenantAndCodeAsync(
            int tenantId,
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0 || string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid tenant id or code provided");
                }

                return await _dbContext.Permissions
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.TenantId == tenantId && e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active permission by tenant and code: {ex.Message}");
            }
        }

        public void Add(PermissionDO permission)
        {
            if (permission is null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            _dbContext.Permissions.Add(permission);
        }

        public void Update(PermissionDO permission)
        {
            if (permission is null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            _dbContext.Permissions.Update(permission);
        }

        public void Remove(PermissionDO permission)
        {
            if (permission is null)
            {
                throw new ArgumentException(nameof(permission));
            }

            _dbContext.Permissions.Remove(permission);
        }

        public async Task<bool> ExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid code provided");
                }

                return await _dbContext.Permissions.AnyAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking permission by code: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid code provided");
                }

                return await _dbContext.Permissions.AnyAsync(
                    e => e.Code == code && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active permission by code: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByTenantAndCodeAsync(
            int tenantId,
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0 || string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid tenant id or code provided");
                }

                return await _dbContext.Permissions.AnyAsync(
                    e => e.TenantId == tenantId && e.Code == code,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking permission by tenant and code: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByTenantAndCodeAsync(
            int tenantId,
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0 || string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid tenant id or code provided");
                }

                return await _dbContext.Permissions.AnyAsync(
                    e => e.TenantId == tenantId && e.Code == code && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active permission by tenant and code: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Permissions.AnyAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking permission by id: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Permissions.AnyAsync(
                    e => e.Id == id && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active permission by id: {ex.Message}");
            }
        }

        #endregion
    }
}
