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
    public sealed class AllocationRepository : IAllocationRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public AllocationRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<AllocationDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Allocations
                    .AsNoTracking()
                    .OrderByDescending(a => a.CreatedOn)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all allocations: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AllocationDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Allocations
                    .OrderByDescending(a => a.CreatedOn)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all allocations: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AllocationDO>> GetByOrderIdAsync(
            int orderId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (orderId == 0)
                {
                    throw new ArgumentException("Invalid order id provided");
                }

                return await _dbContext.Allocations
                    .AsNoTracking()
                    .Where(a => a.OrderId == orderId)
                    .OrderByDescending(a => a.CreatedOn)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching allocations by order id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AllocationDO>> GetByProductIdAsync(
            int productId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (productId == 0)
                {
                    throw new ArgumentException("Invalid product id provided");
                }

                return await _dbContext.Allocations
                    .AsNoTracking()
                    .Where(a => a.ProductId == productId)
                    .OrderByDescending(a => a.CreatedOn)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching allocations by product id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AllocationDO>> GetByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == 0)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.Allocations
                    .AsNoTracking()
                    .Where(a => a.MaterialBatchId == materialBatchId)
                    .OrderByDescending(a => a.CreatedOn)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching allocations by material batch id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AllocationDO>> GetByStatusAsync(
            string status,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrEmpty(status))
                {
                    throw new ArgumentException("Invalid status provided");
                }

                var validStatuses = new[] { "allocated", "picked", "shipped", "released", "cancelled" };
                if (!validStatuses.Contains(status.ToLower()))
                {
                    throw new ArgumentException($"Invalid status: {status}. Valid statuses are: {string.Join(", ", validStatuses)}");
                }

                return await _dbContext.Allocations
                    .AsNoTracking()
                    .Where(a => a.Status == status.ToLower())
                    .OrderByDescending(a => a.CreatedOn)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching allocations by status: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AllocationDO>> GetActiveAllocationsAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Allocations
                    .AsNoTracking()
                    .Where(a => a.Status == "allocated" || a.Status == "picked")
                    .OrderByDescending(a => a.CreatedOn)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active allocations: {ex.Message}");
            }
        }

        public async Task<AllocationDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Allocations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching allocation by id: {ex.Message}");
            }
        }

        public async Task<AllocationDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Allocations
                    .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching allocation by id: {ex.Message}");
            }
        }

        public void Add(AllocationDO allocation)
        {
            if (allocation is null)
            {
                throw new ArgumentNullException(nameof(allocation));
            }

            _dbContext.Allocations.Add(allocation);
        }

        public void Update(AllocationDO allocation)
        {
            if (allocation is null)
            {
                throw new ArgumentNullException(nameof(allocation));
            }

            _dbContext.Allocations.Update(allocation);
        }

        public void Remove(AllocationDO allocation)
        {
            if (allocation is null)
            {
                throw new ArgumentException(nameof(allocation));
            }

            _dbContext.Allocations.Remove(allocation);
        }

        public async Task<bool> ExistsByOrderIdAsync(
            int orderId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (orderId == 0)
                {
                    throw new ArgumentException("Invalid order id provided");
                }

                return await _dbContext.Allocations
                    .AnyAsync(a => a.OrderId == orderId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking allocations by order id: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByProductIdAsync(
            int productId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (productId == 0)
                {
                    throw new ArgumentException("Invalid product id provided");
                }

                return await _dbContext.Allocations
                    .AnyAsync(a => a.ProductId == productId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking allocations by product id: {ex.Message}");
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

                return await _dbContext.Allocations
                    .AnyAsync(a => a.MaterialBatchId == materialBatchId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking allocations by material batch id: {ex.Message}");
            }
        }

        public async Task<decimal> GetTotalAllocatedQuantityByProductAsync(
            int productId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (productId == 0)
                {
                    throw new ArgumentException("Invalid product id provided");
                }

                var activeAllocations = await _dbContext.Allocations
                    .Where(a => a.ProductId == productId &&
                               (a.Status == "allocated" || a.Status == "picked"))
                    .ToListAsync(cancellationToken);

                return activeAllocations.Sum(a => a.Quantity);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while calculating total allocated quantity by product: {ex.Message}");
            }
        }

        public async Task<decimal> GetTotalAllocatedQuantityByMaterialBatchAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == 0)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                var activeAllocations = await _dbContext.Allocations
                    .Where(a => a.MaterialBatchId == materialBatchId &&
                               (a.Status == "allocated" || a.Status == "picked"))
                    .ToListAsync(cancellationToken);

                return activeAllocations.Sum(a => a.Quantity);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while calculating total allocated quantity by material batch: {ex.Message}");
            }
        }

        #endregion
    }
}
