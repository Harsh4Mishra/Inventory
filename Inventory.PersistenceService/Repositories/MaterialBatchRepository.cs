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
    public sealed class MaterialBatchRepository
    : IMaterialBatchRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public MaterialBatchRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.MaterialBatches
                    .AsNoTracking()
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Material Batches : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.MaterialBatches
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Material Batches : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.MaterialBatches
                    .AsNoTracking()
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Material Batches : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.MaterialBatches
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Material Batches : {ex.Message}");
            }
        }

        public async Task<MaterialBatchDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.MaterialBatches
                    .AsNoTracking()
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batch by id : {ex.Message}");
            }
        }

        public async Task<MaterialBatchDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.MaterialBatches
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batch by id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetByMaterialIdAsync(
            int materialId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialId == 0)
                {
                    throw new ArgumentException("Invalid material id provided");
                }

                return await _dbContext.MaterialBatches
                    .AsNoTracking()
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .Where(e => e.MaterialId == materialId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batches by material id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetByMaterialIdToMutateAsync(
            int materialId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialId == 0)
                {
                    throw new ArgumentException("Invalid material id provided");
                }

                return await _dbContext.MaterialBatches
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .Where(e => e.MaterialId == materialId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batches by material id : {ex.Message}");
            }
        }

        public async Task<MaterialBatchDO?> GetByBatchCodeAsync(
            string batchCode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(batchCode))
                {
                    throw new ArgumentException("Invalid batch code provided");
                }

                return await _dbContext.MaterialBatches
                    .AsNoTracking()
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .FirstOrDefaultAsync(e => e.BatchCode == batchCode.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batch by batch code : {ex.Message}");
            }
        }

        public async Task<MaterialBatchDO?> GetByBatchCodeToMutateAsync(
            string batchCode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(batchCode))
                {
                    throw new ArgumentException("Invalid batch code provided");
                }

                return await _dbContext.MaterialBatches
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .FirstOrDefaultAsync(e => e.BatchCode == batchCode.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batch by batch code : {ex.Message}");
            }
        }

        public async Task<MaterialBatchDO?> GetByBarcodeAsync(
            string barcode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(barcode))
                {
                    throw new ArgumentException("Invalid barcode provided");
                }

                return await _dbContext.MaterialBatches
                    .AsNoTracking()
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .FirstOrDefaultAsync(e => e.Barcode == barcode.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batch by barcode : {ex.Message}");
            }
        }

        public async Task<MaterialBatchDO?> GetByBarcodeToMutateAsync(
            string barcode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(barcode))
                {
                    throw new ArgumentException("Invalid barcode provided");
                }

                return await _dbContext.MaterialBatches
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .FirstOrDefaultAsync(e => e.Barcode == barcode.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batch by barcode : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetByVendorIdAsync(
            int vendorId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (vendorId == 0)
                {
                    throw new ArgumentException("Invalid vendor id provided");
                }

                return await _dbContext.MaterialBatches
                    .AsNoTracking()
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .Where(e => e.VendorId == vendorId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batches by vendor id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetByVendorIdToMutateAsync(
            int vendorId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (vendorId == 0)
                {
                    throw new ArgumentException("Invalid vendor id provided");
                }

                return await _dbContext.MaterialBatches
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .Where(e => e.VendorId == vendorId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material batches by vendor id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialBatchDO>> GetExpiringBatchesAsync(
            DateOnly expiryDate,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.MaterialBatches
                    .AsNoTracking()
                    .Include(mb => mb.Material)
                    .Include(mb => mb.Vendor)
                    .Where(e => e.ExpiryDate.HasValue &&
                                e.ExpiryDate.Value <= expiryDate &&
                                e.IsActive &&
                                e.RemainingQuantity > 0)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching expiring material batches : {ex.Message}");
            }
        }

        public void Add(MaterialBatchDO materialBatch)
        {
            if (materialBatch is null)
            {
                throw new ArgumentNullException(nameof(materialBatch));
            }

            _dbContext.MaterialBatches.Add(materialBatch);
        }

        public void Update(MaterialBatchDO materialBatch)
        {
            if (materialBatch is null)
            {
                throw new ArgumentNullException(nameof(materialBatch));
            }

            _dbContext.MaterialBatches.Update(materialBatch);
        }

        public void Remove(MaterialBatchDO materialBatch)
        {
            if (materialBatch is null)
            {
                throw new ArgumentException(nameof(materialBatch));
            }

            _dbContext.MaterialBatches.Remove(materialBatch);
        }

        public async Task<bool> ExistsByBatchCodeAsync(
            string batchCode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(batchCode))
                {
                    throw new ArgumentException("Invalid batch code provided");
                }

                return await _dbContext.MaterialBatches.AnyAsync(i => i.BatchCode == batchCode.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking material batch by batch code : {ex.Message}");
            }
        }

        public async Task<bool> ExistsByBarcodeAsync(
            string barcode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(barcode))
                {
                    throw new ArgumentException("Invalid barcode provided");
                }

                return await _dbContext.MaterialBatches.AnyAsync(i => i.Barcode == barcode.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking material batch by barcode : {ex.Message}");
            }
        }

        #endregion
    }
}
