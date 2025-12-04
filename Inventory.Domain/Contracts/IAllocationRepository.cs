using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IAllocationRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all allocations
        /// </summary>
        Task<IReadOnlyCollection<AllocationDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all allocations to make changes
        /// </summary>
        Task<IReadOnlyCollection<AllocationDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves allocations by order ID
        /// </summary>
        Task<IReadOnlyCollection<AllocationDO>> GetByOrderIdAsync(
            int orderId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves allocations by product ID
        /// </summary>
        Task<IReadOnlyCollection<AllocationDO>> GetByProductIdAsync(
            int productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves allocations by material batch ID
        /// </summary>
        Task<IReadOnlyCollection<AllocationDO>> GetByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves allocations by status
        /// </summary>
        Task<IReadOnlyCollection<AllocationDO>> GetByStatusAsync(
            string status,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active allocations (allocated or picked)
        /// </summary>
        Task<IReadOnlyCollection<AllocationDO>> GetActiveAllocationsAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an allocation by its unique identifier
        /// </summary>
        Task<AllocationDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an allocation by its unique identifier to make changes
        /// </summary>
        Task<AllocationDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new allocation
        /// </summary>
        void Add(AllocationDO allocation);

        /// <summary>
        /// Updates an allocation
        /// </summary>
        void Update(AllocationDO allocation);

        /// <summary>
        /// Removes an allocation
        /// </summary>
        void Remove(AllocationDO allocation);

        /// <summary>
        /// Checks if any allocation exists for the given order
        /// </summary>
        Task<bool> ExistsByOrderIdAsync(
            int orderId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if any allocation exists for the given product
        /// </summary>
        Task<bool> ExistsByProductIdAsync(
            int productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if any allocation exists for the given material batch
        /// </summary>
        Task<bool> ExistsByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets total allocated quantity for a product
        /// </summary>
        Task<decimal> GetTotalAllocatedQuantityByProductAsync(
            int productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets total allocated quantity for a material batch
        /// </summary>
        Task<decimal> GetTotalAllocatedQuantityByMaterialBatchAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
