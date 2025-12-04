using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IBomRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all BOMs
        /// </summary>
        Task<IReadOnlyCollection<BomDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all BOMs to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only approved BOMs
        /// </summary>
        Task<IReadOnlyCollection<BomDO>> GetAllApprovedAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only approved BOMs to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomDO>> GetAllApprovedToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only pending BOMs
        /// </summary>
        Task<IReadOnlyCollection<BomDO>> GetAllPendingAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only pending BOMs to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomDO>> GetAllPendingToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM by its unique identifier
        /// </summary>
        Task<BomDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM by its unique identifier to make changes
        /// </summary>
        Task<BomDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves BOMs by category ID
        /// </summary>
        Task<IReadOnlyCollection<BomDO>> GetByCategoryIdAsync(
            int bomCategoryId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves BOMs by category ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomDO>> GetByCategoryIdToMutateAsync(
            int bomCategoryId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM by its name
        /// </summary>
        Task<BomDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a BOM by its name to make changes
        /// </summary>
        Task<BomDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new BOM
        /// </summary>
        void Add(BomDO bom);

        /// <summary>
        /// Updates a BOM
        /// </summary>
        void Update(BomDO bom);

        /// <summary>
        /// Removes the BOM
        /// </summary>
        void Remove(BomDO bom);

        /// <summary>
        /// Checks whether any BOM exists with the given name
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any BOM exists in the given category
        /// </summary>
        Task<bool> ExistsByCategoryIdAsync(
            int bomCategoryId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
