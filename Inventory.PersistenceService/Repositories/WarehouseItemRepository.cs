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
    public sealed class WarehouseItemRepository : IWarehouseItemRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public WarehouseItemRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<WarehouseItemDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.WarehouseItems
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all warehouse items: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<WarehouseItemDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.WarehouseItems
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all warehouse items: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<WarehouseItemDO>> GetByMaterialBatchIdAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.WarehouseItems
                    .AsNoTracking()
                    .Where(e => e.MaterialBatchId == materialBatchId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching warehouse items by material batch: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<WarehouseItemDO>> GetByMaterialBatchIdToMutateAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.WarehouseItems
                    .Where(e => e.MaterialBatchId == materialBatchId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching warehouse items by material batch: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<WarehouseItemDO>> GetByWarehouseIdAsync(
            Guid warehouseId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid warehouse id provided");
                }

                return await _dbContext.WarehouseItems
                    .AsNoTracking()
                    .Where(e => e.WarehouseId == warehouseId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching warehouse items by warehouse: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<WarehouseItemDO>> GetByWarehouseIdToMutateAsync(
            Guid warehouseId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid warehouse id provided");
                }

                return await _dbContext.WarehouseItems
                    .Where(e => e.WarehouseId == warehouseId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching warehouse items by warehouse: {ex.Message}");
            }
        }

        public async Task<WarehouseItemDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.WarehouseItems
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching warehouse item by id: {ex.Message}");
            }
        }

        public async Task<WarehouseItemDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.WarehouseItems
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching warehouse item by id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<WarehouseItemDO>> GetByLocationAsync(
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseId == Guid.Empty || aisleId == Guid.Empty || rowId == Guid.Empty || trayId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid location parameters provided");
                }

                return await _dbContext.WarehouseItems
                    .AsNoTracking()
                    .Where(e => e.WarehouseId == warehouseId &&
                               e.AisleId == aisleId &&
                               e.RowId == rowId &&
                               e.TrayId == trayId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching warehouse items by location: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<WarehouseItemDO>> GetByLocationToMutateAsync(
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseId == Guid.Empty || aisleId == Guid.Empty || rowId == Guid.Empty || trayId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid location parameters provided");
                }

                return await _dbContext.WarehouseItems
                    .Where(e => e.WarehouseId == warehouseId &&
                               e.AisleId == aisleId &&
                               e.RowId == rowId &&
                               e.TrayId == trayId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching warehouse items by location: {ex.Message}");
            }
        }

        public void Add(WarehouseItemDO warehouseItem)
        {
            if (warehouseItem is null)
            {
                throw new ArgumentNullException(nameof(warehouseItem));
            }

            _dbContext.WarehouseItems.Add(warehouseItem);
        }

        public void Update(WarehouseItemDO warehouseItem)
        {
            if (warehouseItem is null)
            {
                throw new ArgumentNullException(nameof(warehouseItem));
            }

            _dbContext.WarehouseItems.Update(warehouseItem);
        }

        public void Remove(WarehouseItemDO warehouseItem)
        {
            if (warehouseItem is null)
            {
                throw new ArgumentException(nameof(warehouseItem));
            }

            _dbContext.WarehouseItems.Remove(warehouseItem);
        }

        public async Task<bool> ExistsByMaterialBatchIdAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.WarehouseItems.AnyAsync(i => i.MaterialBatchId == materialBatchId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking warehouse item by material batch: {ex.Message}");
            }
        }

        public async Task<bool> ExistsAtLocationAsync(
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseId == Guid.Empty || aisleId == Guid.Empty || rowId == Guid.Empty || trayId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid location parameters provided");
                }

                return await _dbContext.WarehouseItems.AnyAsync(
                    i => i.WarehouseId == warehouseId &&
                         i.AisleId == aisleId &&
                         i.RowId == rowId &&
                         i.TrayId == trayId,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking warehouse item at location: {ex.Message}");
            }
        }

        #endregion
    }
}
