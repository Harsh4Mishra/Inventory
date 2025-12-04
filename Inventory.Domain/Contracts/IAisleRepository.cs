using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IAisleRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all aisles
        /// </summary>
        Task<IReadOnlyCollection<AisleDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all aisles to make changes
        /// </summary>
        Task<IReadOnlyCollection<AisleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an aisle by its unique identifier.
        /// </summary>
        Task<AisleDO?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an aisle by its unique identifier to make changes.
        /// </summary>
        Task<AisleDO?> GetByIdToMutateAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an aisle by its name.
        /// </summary>
        Task<AisleDO?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an aisle by its name to make changes.
        /// </summary>
        Task<AisleDO?> GetByNameToMutateAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves aisles by warehouse id.
        /// </summary>
        Task<IReadOnlyCollection<AisleDO>> GetByWarehouseIdAsync(int warehouseId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new aisle
        /// </summary>
        void Add(AisleDO aisle);

        /// <summary>
        /// Removes the aisle
        /// </summary>
        void Remove(AisleDO aisle);

        /// <summary>
        /// Checks whether any aisle exists with the given name.
        /// </summary>
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);

        #endregion
    }
}
