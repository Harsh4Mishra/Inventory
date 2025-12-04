using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IStorageSectionRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all storage sections
        /// </summary>
        Task<IReadOnlyCollection<StorageSectionDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all storage sections to make changes
        /// </summary>
        Task<IReadOnlyCollection<StorageSectionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active storage sections
        /// </summary>
        Task<IReadOnlyCollection<StorageSectionDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active storage sections to make changes
        /// </summary>
        Task<IReadOnlyCollection<StorageSectionDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a storage section by its unique identifier.
        /// </summary>
        Task<StorageSectionDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a storage section by its unique identifier to make changes.
        /// </summary>
        Task<StorageSectionDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a storage section by its name.
        /// </summary>
        Task<StorageSectionDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a storage section by its name to make changes.
        /// </summary>
        Task<StorageSectionDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new storage section
        /// </summary>
        void Add(StorageSectionDO storageSection);

        /// <summary>
        /// Removes the storage section
        /// </summary>
        void Remove(StorageSectionDO storageSection);

        /// <summary>
        /// Checks whether any storage section exists with the given name.
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
