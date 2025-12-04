using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IWarehouseRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all warehouses
        /// </summary>
        Task<IReadOnlyCollection<WarehouseDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all warehouses to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active warehouses
        /// </summary>
        Task<IReadOnlyCollection<WarehouseDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active warehouses to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a warehouse by its unique identifier.
        /// </summary>
        Task<WarehouseDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a warehouse by its unique identifier to make changes.
        /// </summary>
        Task<WarehouseDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a warehouse by its name.
        /// </summary>
        Task<WarehouseDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a warehouse by its name to make changes.
        /// </summary>
        Task<WarehouseDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new warehouse
        /// </summary>
        void Add(WarehouseDO warehouse);

        /// <summary>
        /// Removes the warehouse
        /// </summary>
        void Remove(WarehouseDO warehouse);

        /// <summary>
        /// Checks whether any warehouse exists with the given name.
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
