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
    public sealed class BomItemRepository : IBomItemRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public BomItemRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<BomItemDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.BomItems
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all BOM items: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.BomItems
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all BOM items: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDO>> GetByBomIdAsync(
            int bomId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomId == 0)
                {
                    throw new ArgumentException("Invalid BOM id provided");
                }

                return await _dbContext.BomItems
                    .AsNoTracking()
                    .Where(e => e.BomId == bomId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM items by BOM id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDO>> GetByBomIdToMutateAsync(
            int bomId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomId == 0)
                {
                    throw new ArgumentException("Invalid BOM id provided");
                }

                return await _dbContext.BomItems
                    .Where(e => e.BomId == bomId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM items by BOM id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDO>> GetByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == 0)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.BomItems
                    .AsNoTracking()
                    .Where(e => e.MaterialBatchId == materialBatchId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM items by material batch id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<BomItemDO>> GetByWarehouseItemIdAsync(
            int warehouseItemId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseItemId == 0)
                {
                    throw new ArgumentException("Invalid warehouse item id provided");
                }

                return await _dbContext.BomItems
                    .AsNoTracking()
                    .Where(e => e.WarehouseItemId == warehouseItemId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM items by warehouse item id: {ex.Message}");
            }
        }

        public async Task<BomItemDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.BomItems
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM item by id: {ex.Message}");
            }
        }

        public async Task<BomItemDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.BomItems
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching BOM item by id: {ex.Message}");
            }
        }

        public void Add(BomItemDO bomItem)
        {
            if (bomItem is null)
            {
                throw new ArgumentNullException(nameof(bomItem));
            }

            _dbContext.BomItems.Add(bomItem);
        }

        public void Update(BomItemDO bomItem)
        {
            if (bomItem is null)
            {
                throw new ArgumentNullException(nameof(bomItem));
            }

            _dbContext.BomItems.Update(bomItem);
        }

        public void Remove(BomItemDO bomItem)
        {
            if (bomItem is null)
            {
                throw new ArgumentException(nameof(bomItem));
            }

            _dbContext.BomItems.Remove(bomItem);
        }

        public async Task<bool> ExistsByBomIdAsync(
            int bomId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomId == 0)
                {
                    throw new ArgumentException("Invalid BOM id provided");
                }

                return await _dbContext.BomItems.AnyAsync(i => i.BomId == bomId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking BOM item by BOM id: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == 0)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.BomItems.AnyAsync(i => i.MaterialBatchId == materialBatchId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking BOM item by material batch id: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByWarehouseItemIdAsync(
            int warehouseItemId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseItemId == 0)
                {
                    throw new ArgumentException("Invalid warehouse item id provided");
                }

                return await _dbContext.BomItems.AnyAsync(i => i.WarehouseItemId == warehouseItemId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking BOM item by warehouse item id: {ex.Message}");
            }
        }

        #endregion
    }
}
