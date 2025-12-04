using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IBomCategoryRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all BOM categories
        /// </summary>
        Task<IReadOnlyCollection<BomCategoryDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all BOM categories to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomCategoryDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM category by its unique identifier
        /// </summary>
        Task<BomCategoryDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM category by its unique identifier to make changes
        /// </summary>
        Task<BomCategoryDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM category by its name
        /// </summary>
        Task<BomCategoryDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM category by its name to make changes
        /// </summary>
        Task<BomCategoryDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new BOM category
        /// </summary>
        void Add(BomCategoryDO category);

        /// <summary>
        /// Updates a BOM category
        /// </summary>
        void Update(BomCategoryDO category);

        /// <summary>
        /// Removes the BOM category
        /// </summary>
        void Remove(BomCategoryDO category);

        /// <summary>
        /// Checks whether any BOM category exists with the given name
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
