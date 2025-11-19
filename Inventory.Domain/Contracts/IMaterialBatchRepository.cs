using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IMaterialBatchRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all material batches
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all material batches to make changes
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active material batches
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active material batches to make changes
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material batch by its unique identifier.
        /// </summary>
        Task<MaterialBatchDO?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material batch by its unique identifier to make changes.
        /// </summary>
        Task<MaterialBatchDO?> GetByIdToMutateAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves material batches by material ID.
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves material batches by material ID to make changes.
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetByMaterialIdToMutateAsync(Guid materialId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material batch by its batch code.
        /// </summary>
        Task<MaterialBatchDO?> GetByBatchCodeAsync(string batchCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material batch by its batch code to make changes.
        /// </summary>
        Task<MaterialBatchDO?> GetByBatchCodeToMutateAsync(string batchCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material batch by its barcode.
        /// </summary>
        Task<MaterialBatchDO?> GetByBarcodeAsync(string barcode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material batch by its barcode to make changes.
        /// </summary>
        Task<MaterialBatchDO?> GetByBarcodeToMutateAsync(string barcode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves material batches by vendor ID.
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetByVendorIdAsync(Guid vendorId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves material batches by vendor ID to make changes.
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetByVendorIdToMutateAsync(Guid vendorId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves material batches that are expiring soon.
        /// </summary>
        Task<IReadOnlyCollection<MaterialBatchDO>> GetExpiringBatchesAsync(DateOnly expiryDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new material batch
        /// </summary>
        void Add(MaterialBatchDO materialBatch);

        /// <summary>
        /// Updates a material batch
        /// </summary>
        void Update(MaterialBatchDO materialBatch);

        /// <summary>
        /// Removes the material batch
        /// </summary>
        void Remove(MaterialBatchDO materialBatch);

        /// <summary>
        /// Checks whether any material batch exists with the given batch code.
        /// </summary>
        Task<bool> ExistsByBatchCodeAsync(string batchCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any material batch exists with the given barcode.
        /// </summary>
        Task<bool> ExistsByBarcodeAsync(string barcode, CancellationToken cancellationToken = default);

        #endregion
    }
}
