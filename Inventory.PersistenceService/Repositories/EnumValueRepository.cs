using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class EnumValueRepository
        : IEnumValueRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public EnumValueRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<EnumValueDO>> GetAllByEnumTypeIdAsync(
            int enumTypeId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.EnumValues
                    .AsNoTracking()
                    .Where(e => e.EnumTypeId == enumTypeId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum values by enum type id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<EnumValueDO>> GetAllByEnumTypeIdToMutateAsync(
            int enumTypeId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.EnumValues
                    .Where(e => e.EnumTypeId == enumTypeId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum values by enum type id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<EnumValueDO>> GetAllActiveByEnumTypeIdAsync(
            int enumTypeId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.EnumValues
                    .AsNoTracking()
                    .Where(e => e.EnumTypeId == enumTypeId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active enum values by enum type id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<EnumValueDO>> GetAllActiveByEnumTypeIdToMutateAsync(
            int enumTypeId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.EnumValues
                    .Where(e => e.EnumTypeId == enumTypeId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active enum values by enum type id: {ex.Message}");
            }
        }

        public async Task<EnumValueDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.EnumValues
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum value by id: {ex.Message}");
            }
        }

        public async Task<EnumValueDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.EnumValues
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum value by id: {ex.Message}");
            }
        }

        public async Task<EnumValueDO?> GetByEnumTypeIdAndNameAsync(
            int enumTypeId,
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.EnumValues
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.EnumTypeId == enumTypeId && e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum value by type id and name: {ex.Message}");
            }
        }

        public async Task<EnumValueDO?> GetByEnumTypeIdAndCodeAsync(
            int enumTypeId,
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (code is null)
                {
                    throw new ArgumentNullException("Invalid code provided");
                }

                return await _dbContext.EnumValues
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.EnumTypeId == enumTypeId && e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum value by type id and code: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByNameAsync(
            int enumTypeId,
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.EnumValues.AnyAsync(e => e.EnumTypeId == enumTypeId && e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking enum value by name: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByCodeAsync(
            int enumTypeId,
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (code is null)
                {
                    throw new ArgumentNullException("Invalid code provided");
                }

                return await _dbContext.EnumValues.AnyAsync(e => e.EnumTypeId == enumTypeId && e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking enum value by code: {ex.Message}");
            }
        }

        #endregion
    }
}
