using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class AppModuleRepository : IAppModuleRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public AppModuleRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<AppModuleDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.AppModules
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all app modules: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AppModuleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.AppModules
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all app modules: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AppModuleDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.AppModules
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active app modules: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AppModuleDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.AppModules
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active app modules: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.AppModules
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching app module by id: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.AppModules
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching app module by id: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetActiveByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.AppModules
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active app module by id: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid code provided");
                }

                return await _dbContext.AppModules
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching app module by code: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetByCodeToMutateAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid code provided");
                }

                return await _dbContext.AppModules
                    .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching app module by code: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetActiveByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Invalid code provided");
                }

                return await _dbContext.AppModules
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active app module by code: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AppModuleDO>> GetByTenantIdAsync(
            int tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                return await _dbContext.AppModules
                    .AsNoTracking()
                    .Where(e => e.TenantId == tenantId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching app modules by tenant id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AppModuleDO>> GetByTenantIdToMutateAsync(
            int tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                return await _dbContext.AppModules
                    .Where(e => e.TenantId == tenantId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching app modules by tenant id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AppModuleDO>> GetActiveByTenantIdAsync(
            int tenantId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (tenantId == 0)
                {
                    throw new ArgumentException("Invalid tenant id provided");
                }

                return await _dbContext.AppModules
                    .AsNoTracking()
                    .Where(e => e.TenantId == tenantId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active app modules by tenant id: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetByTenantAndCodeAsync(
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

                return await _dbContext.AppModules
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.TenantId == tenantId && e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching app module by tenant and code: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetByTenantAndCodeToMutateAsync(
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

                return await _dbContext.AppModules
                    .FirstOrDefaultAsync(e => e.TenantId == tenantId && e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching app module by tenant and code: {ex.Message}");
            }
        }

        public async Task<AppModuleDO?> GetActiveByTenantAndCodeAsync(
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

                return await _dbContext.AppModules
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.TenantId == tenantId && e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active app module by tenant and code: {ex.Message}");
            }
        }

        public void Add(AppModuleDO appModule)
        {
            if (appModule is null)
            {
                throw new ArgumentNullException(nameof(appModule));
            }

            _dbContext.AppModules.Add(appModule);
        }

        public void Update(AppModuleDO appModule)
        {
            if (appModule is null)
            {
                throw new ArgumentNullException(nameof(appModule));
            }

            _dbContext.AppModules.Update(appModule);
        }

        public void Remove(AppModuleDO appModule)
        {
            if (appModule is null)
            {
                throw new ArgumentException(nameof(appModule));
            }

            _dbContext.AppModules.Remove(appModule);
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

                return await _dbContext.AppModules.AnyAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking app module by code: {ex.Message}");
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

                return await _dbContext.AppModules.AnyAsync(
                    e => e.Code == code && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active app module by code: {ex.Message}");
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

                return await _dbContext.AppModules.AnyAsync(
                    e => e.TenantId == tenantId && e.Code == code,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking app module by tenant and code: {ex.Message}");
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

                return await _dbContext.AppModules.AnyAsync(
                    e => e.TenantId == tenantId && e.Code == code && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active app module by tenant and code: {ex.Message}");
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

                return await _dbContext.AppModules.AnyAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking app module by id: {ex.Message}");
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

                return await _dbContext.AppModules.AnyAsync(
                    e => e.Id == id && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active app module by id: {ex.Message}");
            }
        }

        #endregion
    }
}
