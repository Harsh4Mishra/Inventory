using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class MaterialStorageRuleRepository : IMaterialStorageRuleRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public MaterialStorageRuleRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.MaterialStorageRules
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all material storage rules: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.MaterialStorageRules
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all material storage rules: {ex.Message}");
            }
        }

        public async Task<MaterialStorageRuleDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.MaterialStorageRules
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material storage rule by id: {ex.Message}");
            }
        }

        public async Task<MaterialStorageRuleDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.MaterialStorageRules
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material storage rule by id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetByMaterialIdAsync(
            Guid materialId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid material id provided");
                }

                return await _dbContext.MaterialStorageRules
                    .AsNoTracking()
                    .Where(e => e.MaterialId == materialId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material storage rules by material id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetByMaterialIdToMutateAsync(
            Guid materialId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid material id provided");
                }

                return await _dbContext.MaterialStorageRules
                    .Where(e => e.MaterialId == materialId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material storage rules by material id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetByPreferredSectionIdAsync(
            Guid preferredSectionId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (preferredSectionId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid preferred section id provided");
                }

                return await _dbContext.MaterialStorageRules
                    .AsNoTracking()
                    .Where(e => e.PreferredSectionId == preferredSectionId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material storage rules by preferred section id: {ex.Message}");
            }
        }

        public void Add(MaterialStorageRuleDO rule)
        {
            if (rule is null)
            {
                throw new ArgumentNullException(nameof(rule));
            }

            _dbContext.MaterialStorageRules.Add(rule);
        }

        public void Update(MaterialStorageRuleDO rule)
        {
            if (rule is null)
            {
                throw new ArgumentNullException(nameof(rule));
            }

            _dbContext.MaterialStorageRules.Update(rule);
        }

        public void Remove(MaterialStorageRuleDO rule)
        {
            if (rule is null)
            {
                throw new ArgumentException(nameof(rule));
            }

            _dbContext.MaterialStorageRules.Remove(rule);
        }

        public async Task<bool> ExistsByMaterialIdAsync(
            Guid materialId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid material id provided");
                }

                return await _dbContext.MaterialStorageRules.AnyAsync(i => i.MaterialId == materialId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking material storage rule by material id: {ex.Message}");
            }
        }

        #endregion
    }
}
