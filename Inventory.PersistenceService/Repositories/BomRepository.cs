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
    public sealed class BomRepository : IBomRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public BomRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<BomDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Boms
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all BOMs: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Boms
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all BOMs: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomDO>> GetAllApprovedAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Boms
                    .AsNoTracking()
                    .Where(e => e.IsApproved)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all approved BOMs: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomDO>> GetAllApprovedToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Boms
                    .Where(e => e.IsApproved)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all approved BOMs: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomDO>> GetAllPendingAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Boms
                    .AsNoTracking()
                    .Where(e => !e.IsApproved)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all pending BOMs: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomDO>> GetAllPendingToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Boms
                    .Where(e => !e.IsApproved)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all pending BOMs: {ex.Message}");
            }
        }

        public async Task<BomDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Boms
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM by id: {ex.Message}");
            }
        }

        public async Task<BomDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Boms
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM by id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomDO>> GetByCategoryIdAsync(
            Guid bomCategoryId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomCategoryId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid BOM category id provided");
                }

                return await _dbContext.Boms
                    .AsNoTracking()
                    .Where(e => e.BomCategoryId == bomCategoryId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOMs by category id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomDO>> GetByCategoryIdToMutateAsync(
            Guid bomCategoryId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomCategoryId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid BOM category id provided");
                }

                return await _dbContext.Boms
                    .Where(e => e.BomCategoryId == bomCategoryId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOMs by category id: {ex.Message}");
            }
        }

        public async Task<BomDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Boms
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM by name: {ex.Message}");
            }
        }

        public async Task<BomDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Boms
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM by name: {ex.Message}");
            }
        }

        public void Add(BomDO bom)
        {
            if (bom is null)
            {
                throw new ArgumentNullException(nameof(bom));
            }

            _dbContext.Boms.Add(bom);
        }

        public void Update(BomDO bom)
        {
            if (bom is null)
            {
                throw new ArgumentNullException(nameof(bom));
            }

            _dbContext.Boms.Update(bom);
        }

        public void Remove(BomDO bom)
        {
            if (bom is null)
            {
                throw new ArgumentException(nameof(bom));
            }

            _dbContext.Boms.Remove(bom);
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

                return await _dbContext.Boms.AnyAsync(i => i.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking BOM by name: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByCategoryIdAsync(
            Guid bomCategoryId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomCategoryId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid BOM category id provided");
                }

                return await _dbContext.Boms.AnyAsync(i => i.BomCategoryId == bomCategoryId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking BOM by category id: {ex.Message}");
            }
        }

        #endregion
    }
}
