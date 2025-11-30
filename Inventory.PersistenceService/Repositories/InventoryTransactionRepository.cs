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
    public sealed class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public InventoryTransactionRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<InventoryTransactionDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.InventoryTransactions
                    .AsNoTracking()
                    .OrderByDescending(t => t.TransactionTime)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all inventory transactions: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<InventoryTransactionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.InventoryTransactions
                    .OrderByDescending(t => t.TransactionTime)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all inventory transactions: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<InventoryTransactionDO>> GetByMaterialBatchIdAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.InventoryTransactions
                    .AsNoTracking()
                    .Where(t => t.MaterialBatchId == materialBatchId)
                    .OrderByDescending(t => t.TransactionTime)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching transactions by material batch: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<InventoryTransactionDO>> GetByProductIdAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (productId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid product id provided");
                }

                return await _dbContext.InventoryTransactions
                    .AsNoTracking()
                    .Where(t => t.ProductId == productId)
                    .OrderByDescending(t => t.TransactionTime)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching transactions by product: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<InventoryTransactionDO>> GetByTransactionTypeAsync(
            string transactionType,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrEmpty(transactionType))
                {
                    throw new ArgumentException("Invalid transaction type provided");
                }

                return await _dbContext.InventoryTransactions
                    .AsNoTracking()
                    .Where(t => t.TransactionType == transactionType.ToLower())
                    .OrderByDescending(t => t.TransactionTime)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching transactions by type: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<InventoryTransactionDO>> GetByWarehouseIdAsync(
            Guid warehouseId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid warehouse id provided");
                }

                return await _dbContext.InventoryTransactions
                    .AsNoTracking()
                    .Where(t => t.FromWarehouseId == warehouseId || t.ToWarehouseId == warehouseId)
                    .OrderByDescending(t => t.TransactionTime)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching transactions by warehouse: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<InventoryTransactionDO>> GetByDateRangeAsync(
            DateTime startDate,
            DateTime endDate,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (startDate > endDate)
                {
                    throw new ArgumentException("Start date cannot be after end date");
                }

                return await _dbContext.InventoryTransactions
                    .AsNoTracking()
                    .Where(t => t.TransactionTime >= startDate && t.TransactionTime <= endDate)
                    .OrderByDescending(t => t.TransactionTime)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching transactions by date range: {ex.Message}");
            }
        }

        public async Task<InventoryTransactionDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                //if (id <= 0)
                //{
                //    throw new ArgumentException("Invalid id provided");
                //}

                // Convert long to string for comparison since Id is string in DO but long in DB
                var idString = id.ToString();
                return await _dbContext.InventoryTransactions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(t => t.Id.ToString() == idString, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching transaction by id: {ex.Message}");
            }
        }

        public async Task<InventoryTransactionDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                //if (id <= 0)
                //{
                //    throw new ArgumentException("Invalid id provided");
                //}

                // Convert long to string for comparison since Id is string in DO but long in DB
                var idString = id.ToString();
                return await _dbContext.InventoryTransactions
                    .FirstOrDefaultAsync(t => t.Id.ToString() == idString, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching transaction by id: {ex.Message}");
            }
        }

        public async Task<InventoryTransactionDO?> GetByUUIDAsync(
            Guid uuid,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (uuid == Guid.Empty)
                {
                    throw new ArgumentException("Invalid uuid provided");
                }

                return await _dbContext.InventoryTransactions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(t => t.TransactionUUID == uuid, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching transaction by uuid: {ex.Message}");
            }
        }

        public void Add(InventoryTransactionDO transaction)
        {
            if (transaction is null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _dbContext.InventoryTransactions.Add(transaction);
        }

        public void Update(InventoryTransactionDO transaction)
        {
            if (transaction is null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _dbContext.InventoryTransactions.Update(transaction);
        }

        public void Remove(InventoryTransactionDO transaction)
        {
            if (transaction is null)
            {
                throw new ArgumentException(nameof(transaction));
            }

            _dbContext.InventoryTransactions.Remove(transaction);
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

                return await _dbContext.InventoryTransactions
                    .AnyAsync(t => t.MaterialBatchId == materialBatchId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking transactions by material batch: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByProductIdAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (productId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid product id provided");
                }

                return await _dbContext.InventoryTransactions
                    .AnyAsync(t => t.ProductId == productId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking transactions by product: {ex.Message}");
            }
        }

        public async Task<decimal> GetCurrentStockByMaterialBatchAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                var transactions = await _dbContext.InventoryTransactions
                    .Where(t => t.MaterialBatchId == materialBatchId)
                    .ToListAsync(cancellationToken);

                return CalculateCurrentStock(transactions);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while calculating stock for material batch: {ex.Message}");
            }
        }

        public async Task<decimal> GetCurrentStockByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (productId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid product id provided");
                }

                var transactions = await _dbContext.InventoryTransactions
                    .Where(t => t.ProductId == productId)
                    .ToListAsync(cancellationToken);

                return CalculateCurrentStock(transactions);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while calculating stock for product: {ex.Message}");
            }
        }

        private decimal CalculateCurrentStock(IEnumerable<InventoryTransactionDO> transactions)
        {
            decimal stock = 0;

            foreach (var transaction in transactions)
            {
                switch (transaction.TransactionType.ToLower())
                {
                    case "receive":
                    case "adjust" when transaction.Quantity > 0:
                        stock += transaction.Quantity;
                        break;
                    case "issue":
                    case "adjust" when transaction.Quantity < 0:
                        stock -= Math.Abs(transaction.Quantity);
                        break;
                    case "transfer":
                        // For transfers, we need to consider both from and to locations
                        // This is a simplified calculation - you might need to adjust based on your business logic
                        if (transaction.FromWarehouseId.HasValue)
                        {
                            stock -= transaction.Quantity;
                        }
                        if (transaction.ToWarehouseId.HasValue)
                        {
                            stock += transaction.Quantity;
                        }
                        break;
                }
            }

            return stock;
        }

        #endregion
    }
}
