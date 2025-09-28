using Microsoft.EntityFrameworkCore;
using Inventory.Domain.Contracts;
using Inventory.PersistenceService.Configurations;
using Inventory.Domain.DomainObjects;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class RoleRepository
    : IRoleRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public RoleRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<RoleDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Roles
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Roles : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RoleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Roles
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Roles : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RoleDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Roles
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Roles : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<RoleDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Roles
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Roles : {ex.Message}");
            }
        }

        public async Task<RoleDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Roles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role by id : {ex.Message}");
            }
        }

        public async Task<RoleDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Roles
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role by id : {ex.Message}");
            }
        }

        public async Task<RoleDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Roles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role by name : {ex.Message}");
            }
        }

        public async Task<RoleDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Roles
                    //.Include(e => e.Categories)
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching role by name : {ex.Message}");
            }
        }

        public void Add(RoleDO role)
        {
            if (role is null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            _dbContext.Roles.Add(role);
        }

        public void Update(RoleDO role)
        {
            if (role is null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            _dbContext.Roles.Update(role);
        }

        public void Remove(RoleDO role)
        {
            if (role is null)
            {
                throw new ArgumentException(nameof(role));
            }

            _dbContext.Roles.Remove(role);
        }

        public async Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Roles.AnyAsync(i => i.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking role by name : {ex.Message}");
            }
        }

        #endregion
    }
}
