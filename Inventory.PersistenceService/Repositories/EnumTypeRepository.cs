using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class EnumTypeRepository
        : IEnumTypeRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public EnumTypeRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<EnumTypeDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.EnumTypes
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all enum types: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<EnumTypeDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.EnumTypes
                    .Include(e => e.EnumValues)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all enum types: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<EnumTypeDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.EnumTypes
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active enum types: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<EnumTypeDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.EnumTypes
                    .Where(e => e.IsActive)
                    .Include(e => e.EnumValues)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active enum types: {ex.Message}");
            }
        }

        public async Task<EnumTypeDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.EnumTypes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum type by id: {ex.Message}");
            }
        }

        public async Task<EnumTypeDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.EnumTypes
                    .Include(e => e.EnumValues)
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum type by id: {ex.Message}");
            }
        }

        public async Task<EnumTypeDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.EnumTypes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum type by name: {ex.Message}");
            }
        }

        public async Task<EnumTypeDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.EnumTypes
                    .Include(e => e.EnumValues)
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum type by name: {ex.Message}");
            }
        }

        public async Task<EnumTypeDO?> GetByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (code is null)
                {
                    throw new ArgumentNullException("Invalid code provided");
                }

                return await _dbContext.EnumTypes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum type by code: {ex.Message}");
            }
        }

        public async Task<EnumTypeDO?> GetByCodeToMutateAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (code is null)
                {
                    throw new ArgumentNullException("Invalid code provided");
                }

                return await _dbContext.EnumTypes
                    .Include(e => e.EnumValues)
                    .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching enum type by code: {ex.Message}");
            }
        }

        public void Add(EnumTypeDO enumType)
        {
            if (enumType is null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }

            _dbContext.EnumTypes.Add(enumType);
        }

        public void Update(EnumTypeDO enumType)
        {
            if (enumType is null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }

            _dbContext.EnumTypes.Update(enumType);
        }

        public void Remove(EnumTypeDO enumType)
        {
            if (enumType is null)
            {
                throw new ArgumentException(nameof(enumType));
            }

            _dbContext.EnumTypes.Remove(enumType);
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

                return await _dbContext.EnumTypes.AnyAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking enum type by name: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (code is null)
                {
                    throw new ArgumentNullException("Invalid code provided");
                }

                return await _dbContext.EnumTypes.AnyAsync(e => e.Code == code, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking enum type by code: {ex.Message}");
            }
        }

        //public async Task<int> GetMaxCodeValueAsync(string prefix, CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        var maxCode = await _dbContext.EnumTypes
        //            .Where(e => e.Code.StartsWith(prefix))
        //            .MaxAsync(e => (int?)e.Code.Substring(prefix.Length), cancellationToken);

        //        return maxCode ?? 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"EFCore error while getting max code value: {ex.Message}");
        //    }
        //}

        public async Task<IReadOnlyCollection<EnumValueDO>> GetAllEnumValuesByTypeIdAsync(int enumTypeId, CancellationToken cancellationToken = default)
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
                throw new Exception($"EFCore error while fetching enum values by type id: {ex.Message}");
            }
        }

        #endregion
    }
}
