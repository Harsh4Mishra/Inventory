using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IInventoryTransactionRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all inventory transactions
        /// </summary>
        Task<IReadOnlyCollection<InventoryTransactionDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all inventory transactions to make changes
        /// </summary>
        Task<IReadOnlyCollection<InventoryTransactionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves inventory transactions by material batch ID
        /// </summary>
        Task<IReadOnlyCollection<InventoryTransactionDO>> GetByMaterialBatchIdAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves inventory transactions by product ID
        /// </summary>
        Task<IReadOnlyCollection<InventoryTransactionDO>> GetByProductIdAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves inventory transactions by transaction type
        /// </summary>
        Task<IReadOnlyCollection<InventoryTransactionDO>> GetByTransactionTypeAsync(
            string transactionType,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves inventory transactions by warehouse ID
        /// </summary>
        Task<IReadOnlyCollection<InventoryTransactionDO>> GetByWarehouseIdAsync(
            Guid warehouseId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves inventory transactions within a date range
        /// </summary>
        Task<IReadOnlyCollection<InventoryTransactionDO>> GetByDateRangeAsync(
            DateTime startDate,
            DateTime endDate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a transaction by its unique identifier (long - bigserial)
        /// </summary>
        Task<InventoryTransactionDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a transaction by its unique identifier to make changes (long - bigserial)
        /// </summary>
        Task<InventoryTransactionDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a transaction by its UUID
        /// </summary>
        Task<InventoryTransactionDO?> GetByUUIDAsync(
            Guid uuid,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new inventory transaction
        /// </summary>
        void Add(InventoryTransactionDO transaction);

        /// <summary>
        /// Updates an inventory transaction
        /// </summary>
        void Update(InventoryTransactionDO transaction);

        /// <summary>
        /// Removes an inventory transaction
        /// </summary>
        void Remove(InventoryTransactionDO transaction);

        /// <summary>
        /// Checks if any transaction exists for the given material batch
        /// </summary>
        Task<bool> ExistsByMaterialBatchIdAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if any transaction exists for the given product
        /// </summary>
        Task<bool> ExistsByProductIdAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the current stock level for a material batch
        /// </summary>
        Task<decimal> GetCurrentStockByMaterialBatchAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the current stock level for a product
        /// </summary>
        Task<decimal> GetCurrentStockByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
