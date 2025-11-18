using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IMaterialRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all materials
        /// </summary>
        Task<IReadOnlyCollection<MaterialDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all materials to make changes
        /// </summary>
        Task<IReadOnlyCollection<MaterialDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active materials
        /// </summary>
        Task<IReadOnlyCollection<MaterialDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active materials to make changes
        /// </summary>
        Task<IReadOnlyCollection<MaterialDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material by its unique identifier.
        /// </summary>
        Task<MaterialDO?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material by its unique identifier to make changes.
        /// </summary>
        Task<MaterialDO?> GetByIdToMutateAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material by its SKU.
        /// </summary>
        Task<MaterialDO?> GetBySkuAsync(string sku, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material by its SKU to make changes.
        /// </summary>
        Task<MaterialDO?> GetBySkuToMutateAsync(string sku, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material by its name.
        /// </summary>
        Task<MaterialDO?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material by its name to make changes.
        /// </summary>
        Task<MaterialDO?> GetByNameToMutateAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves materials by CAS number.
        /// </summary>
        Task<MaterialDO?> GetByCasNumberAsync(string casNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves materials by CAS number to make changes.
        /// </summary>
        Task<MaterialDO?> GetByCasNumberToMutateAsync(string casNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new material
        /// </summary>
        void Add(MaterialDO material);

        /// <summary>
        /// Updates a material
        /// </summary>
        void Update(MaterialDO material);

        /// <summary>
        /// Removes the material
        /// </summary>
        void Remove(MaterialDO material);

        /// <summary>
        /// Checks whether any material exists with the given SKU.
        /// </summary>
        Task<bool> ExistsBySkuAsync(string sku, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any material exists with the given name.
        /// </summary>
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any material exists with the given CAS number.
        /// </summary>
        Task<bool> ExistsByCasNumberAsync(string casNumber, CancellationToken cancellationToken = default);

        #endregion
    }
}
