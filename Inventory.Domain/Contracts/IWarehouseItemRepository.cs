using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IWarehouseItemRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all warehouse items
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all warehouse items to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by material batch ID
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by material batch ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByMaterialBatchIdToMutateAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by warehouse ID
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByWarehouseIdAsync(
            int warehouseId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by warehouse ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByWarehouseIdToMutateAsync(
            int warehouseId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a warehouse item by its unique identifier
        /// </summary>
        Task<WarehouseItemDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a warehouse item by its unique identifier to make changes
        /// </summary>
        Task<WarehouseItemDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by location
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByLocationAsync(
            int warehouseId,
            int aisleId,
            int rowId,
            int trayId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by location to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByLocationToMutateAsync(
            int warehouseId,
            int aisleId,
            int rowId,
            int trayId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new warehouse item
        /// </summary>
        void Add(WarehouseItemDO warehouseItem);

        /// <summary>
        /// Removes the warehouse item
        /// </summary>
        void Remove(WarehouseItemDO warehouseItem);

        /// <summary>
        /// Checks whether any warehouse item exists with the given material batch ID
        /// </summary>
        Task<bool> ExistsByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any warehouse item exists at the specified location
        /// </summary>
        Task<bool> ExistsAtLocationAsync(
            int warehouseId,
            int aisleId,
            int rowId,
            int trayId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
