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
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by material batch ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByMaterialBatchIdToMutateAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by warehouse ID
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByWarehouseIdAsync(
            Guid warehouseId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by warehouse ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByWarehouseIdToMutateAsync(
            Guid warehouseId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a warehouse item by its unique identifier
        /// </summary>
        Task<WarehouseItemDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a warehouse item by its unique identifier to make changes
        /// </summary>
        Task<WarehouseItemDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by location
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByLocationAsync(
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves warehouse items by location to make changes
        /// </summary>
        Task<IReadOnlyCollection<WarehouseItemDO>> GetByLocationToMutateAsync(
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
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
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any warehouse item exists at the specified location
        /// </summary>
        Task<bool> ExistsAtLocationAsync(
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
