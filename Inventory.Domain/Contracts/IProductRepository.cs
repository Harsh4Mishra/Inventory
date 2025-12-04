using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IProductRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all products
        /// </summary>
        Task<IReadOnlyCollection<ProductDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all products to make changes
        /// </summary>
        Task<IReadOnlyCollection<ProductDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active products
        /// </summary>
        Task<IReadOnlyCollection<ProductDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active products to make changes
        /// </summary>
        Task<IReadOnlyCollection<ProductDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        Task<ProductDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by its unique identifier to make changes.
        /// </summary>
        Task<ProductDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by its name.
        /// </summary>
        Task<ProductDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by its name to make changes.
        /// </summary>
        Task<ProductDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by its SKU.
        /// </summary>
        Task<ProductDO?> GetBySkuAsync(
            string sku,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by its SKU to make changes.
        /// </summary>
        Task<ProductDO?> GetBySkuToMutateAsync(
            string sku,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves products by BOM ID.
        /// </summary>
        Task<IReadOnlyCollection<ProductDO>> GetByBomIdAsync(
            int bomId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves products by BOM ID to make changes.
        /// </summary>
        Task<IReadOnlyCollection<ProductDO>> GetByBomIdToMutateAsync(
            int bomId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new product
        /// </summary>
        void Add(ProductDO product);

        /// <summary>
        /// Updates a product
        /// </summary>
        void Update(ProductDO product);

        /// <summary>
        /// Removes the product
        /// </summary>
        void Remove(ProductDO product);

        /// <summary>
        /// Checks whether any product exists with the given SKU.
        /// </summary>
        Task<bool> ExistsBySkuAsync(
            string sku,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any product exists with the given name.
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
