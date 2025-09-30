using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class OrganizationRepository
        : IOrganizationRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public OrganizationRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<OrganizationDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Organizations
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all organizations: {ex.Message}", ex);
            }
        }

        public async Task<IReadOnlyCollection<OrganizationDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Organizations
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all organizations: {ex.Message}", ex);
            }
        }

        public async Task<IReadOnlyCollection<OrganizationDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Organizations
                    .AsNoTracking()
                    .Where(o => o.IsActive) // Active and not deleted
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active organizations: {ex.Message}", ex);
            }
        }

        public async Task<IReadOnlyCollection<OrganizationDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Organizations
                    .Where(o => o.IsActive ) // Active and not deleted
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active organizations: {ex.Message}", ex);
            }
        }

        public async Task<IReadOnlyCollection<OrganizationDO>> GetAllUndeletedAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Organizations
                    .AsNoTracking()// Not deleted (includes both active and inactive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all undeleted organizations: {ex.Message}", ex);
            }
        }

        public async Task<IReadOnlyCollection<OrganizationDO>> GetAllUndeletedToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Organizations
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all undeleted organizations: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Organizations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Id == id , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching organization by id: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Organizations
                    .FirstOrDefaultAsync(o => o.Id == id , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching organization by id: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetActiveByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Organizations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Id == id && o.IsActive , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active organization by id: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Organizations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Name == name , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching organization by name: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Organizations
                    .FirstOrDefaultAsync(o => o.Name == name , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching organization by name: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetActiveByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Organizations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Name == name && o.IsActive , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active organization by name: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    return null; // Code is optional, so return null if not provided
                }

                return await _dbContext.Organizations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Code == code , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching organization by code: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetByCodeToMutateAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    return null; // Code is optional, so return null if not provided
                }

                return await _dbContext.Organizations
                    .FirstOrDefaultAsync(o => o.Code == code , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching organization by code: {ex.Message}", ex);
            }
        }

        public async Task<OrganizationDO?> GetActiveByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    return null; // Code is optional, so return null if not provided
                }

                return await _dbContext.Organizations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Code == code && o.IsActive , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active organization by code: {ex.Message}", ex);
            }
        }

        public void Add(OrganizationDO organization)
        {
            if (organization is null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            _dbContext.Organizations.Add(organization);
        }

        public void Update(OrganizationDO organization)
        {
            if (organization is null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            _dbContext.Organizations.Update(organization);
        }

        public void Remove(OrganizationDO organization)
        {
            if (organization is null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            _dbContext.Organizations.Remove(organization);
        }

        public void SoftDelete(OrganizationDO organization)
        {
            if (organization is null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            // Soft delete is handled by the domain object, we just need to update
            _dbContext.Organizations.Update(organization);
        }

        public async Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Organizations
                    .AnyAsync(o => o.Name == name , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking organization by name: {ex.Message}", ex);
            }
        }

        public async Task<bool> ActiveExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Organizations
                    .AnyAsync(o => o.Name == name && o.IsActive , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active organization by name: {ex.Message}", ex);
            }
        }

        public async Task<bool> ExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    return false; // Code is optional, so return false if not provided
                }

                return await _dbContext.Organizations
                    .AnyAsync(o => o.Code == code , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking organization by code: {ex.Message}", ex);
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
                    return false; // Code is optional, so return false if not provided
                }

                return await _dbContext.Organizations
                    .AnyAsync(o => o.Code == code && o.IsActive , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active organization by code: {ex.Message}", ex);
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

                return await _dbContext.Organizations
                    .AnyAsync(o => o.Id == id , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking organization by id: {ex.Message}", ex);
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

                return await _dbContext.Organizations
                    .AnyAsync(o => o.Id == id && o.IsActive , cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active organization by id: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
