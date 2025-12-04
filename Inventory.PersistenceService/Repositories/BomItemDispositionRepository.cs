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
    public sealed class BomItemDispositionRepository : IBomItemDispositionRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public BomItemDispositionRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<BomItemDispositionDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.BomItemDispositions
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all BOM Item Dispositions : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDispositionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.BomItemDispositions
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all BOM Item Dispositions : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDispositionDO>> GetByBomItemIdAsync(
            int bomItemId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomItemId == 0)
                {
                    throw new ArgumentException("Invalid bom item id provided");
                }

                return await _dbContext.BomItemDispositions
                    .AsNoTracking()
                    .Where(e => e.BomItemId == bomItemId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching dispositions by bom item id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDispositionDO>> GetByBomItemIdToMutateAsync(
            int bomItemId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomItemId == 0)
                {
                    throw new ArgumentException("Invalid bom item id provided");
                }

                return await _dbContext.BomItemDispositions
                    .Where(e => e.BomItemId == bomItemId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching dispositions by bom item id : {ex.Message}");
            }
        }

        public async Task<BomItemDispositionDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.BomItemDispositions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching disposition by id : {ex.Message}");
            }
        }

        public async Task<BomItemDispositionDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.BomItemDispositions
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching disposition by id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDispositionDO>> GetByDispositionAsync(
            string disposition,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(disposition))
                {
                    throw new ArgumentException("Invalid disposition provided");
                }

                return await _dbContext.BomItemDispositions
                    .AsNoTracking()
                    .Where(e => e.Disposition == disposition)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching dispositions by type : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDispositionDO>> GetByDispositionToMutateAsync(
            string disposition,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(disposition))
                {
                    throw new ArgumentException("Invalid disposition provided");
                }

                return await _dbContext.BomItemDispositions
                    .Where(e => e.Disposition == disposition)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching dispositions by type : {ex.Message}");
            }
        }

        public void Add(BomItemDispositionDO bomItemDisposition)
        {
            if (bomItemDisposition is null)
            {
                throw new ArgumentNullException(nameof(bomItemDisposition));
            }

            _dbContext.BomItemDispositions.Add(bomItemDisposition);
        }

        public void Update(BomItemDispositionDO bomItemDisposition)
        {
            if (bomItemDisposition is null)
            {
                throw new ArgumentNullException(nameof(bomItemDisposition));
            }

            _dbContext.BomItemDispositions.Update(bomItemDisposition);
        }

        public void Remove(BomItemDispositionDO bomItemDisposition)
        {
            if (bomItemDisposition is null)
            {
                throw new ArgumentException(nameof(bomItemDisposition));
            }

            _dbContext.BomItemDispositions.Remove(bomItemDisposition);
        }

        public async Task<bool> ExistsByBomItemIdAsync(
            int bomItemId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomItemId == 0)
                {
                    throw new ArgumentException("Invalid bom item id provided");
                }

                return await _dbContext.BomItemDispositions.AnyAsync(i => i.BomItemId == bomItemId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking dispositions by bom item id : {ex.Message}");
            }
        }

        #endregion
    }
}
