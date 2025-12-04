using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IBomItemRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all BOM items
        /// </summary>
        Task<IReadOnlyCollection<BomItemDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all BOM items to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomItemDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves BOM items by BOM ID
        /// </summary>
        Task<IReadOnlyCollection<BomItemDO>> GetByBomIdAsync(
            int bomId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves BOM items by BOM ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomItemDO>> GetByBomIdToMutateAsync(
            int bomId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves BOM items by material batch ID
        /// </summary>
        Task<IReadOnlyCollection<BomItemDO>> GetByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves BOM items by warehouse item ID
        /// </summary>
        Task<IReadOnlyCollection<BomItemDO>> GetByWarehouseItemIdAsync(
            int warehouseItemId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM item by its unique identifier
        /// </summary>
        Task<BomItemDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM item by its unique identifier to make changes
        /// </summary>
        Task<BomItemDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new BOM item
        /// </summary>
        void Add(BomItemDO bomItem);

        /// <summary>
        /// Updates a BOM item
        /// </summary>
        void Update(BomItemDO bomItem);

        /// <summary>
        /// Removes the BOM item
        /// </summary>
        void Remove(BomItemDO bomItem);

        /// <summary>
        /// Checks whether any BOM item exists for the given BOM ID
        /// </summary>
        Task<bool> ExistsByBomIdAsync(
            int bomId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any BOM item exists for the given material batch ID
        /// </summary>
        Task<bool> ExistsByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any BOM item exists for the given warehouse item ID
        /// </summary>
        Task<bool> ExistsByWarehouseItemIdAsync(
            int warehouseItemId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
