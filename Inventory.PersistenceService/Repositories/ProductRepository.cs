using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public ProductRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<ProductDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Products
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Products : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<ProductDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Products
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Products : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<ProductDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Products
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Products : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<ProductDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Products
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Products : {ex.Message}");
            }
        }

        public async Task<ProductDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching product by id : {ex.Message}");
            }
        }

        public async Task<ProductDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Products
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching product by id : {ex.Message}");
            }
        }

        public async Task<ProductDO?> GetBySkuAsync(
            string sku,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sku))
                {
                    throw new ArgumentException("Invalid SKU provided");
                }

                return await _dbContext.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Sku == sku, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching product by SKU : {ex.Message}");
            }
        }

        public async Task<ProductDO?> GetBySkuToMutateAsync(
            string sku,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sku))
                {
                    throw new ArgumentException("Invalid SKU provided");
                }

                return await _dbContext.Products
                    .FirstOrDefaultAsync(e => e.Sku == sku, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching product by SKU : {ex.Message}");
            }
        }

        public async Task<ProductDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching product by name : {ex.Message}");
            }
        }

        public async Task<ProductDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Products
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching product by name : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<ProductDO>> GetByBomIdAsync(
            Guid bomId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid BOM ID provided");
                }

                return await _dbContext.Products
                    .AsNoTracking()
                    .Where(e => e.BomId == bomId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching products by BOM ID : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<ProductDO>> GetByBomIdToMutateAsync(
            Guid bomId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (bomId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid BOM ID provided");
                }

                return await _dbContext.Products
                    .Where(e => e.BomId == bomId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching products by BOM ID : {ex.Message}");
            }
        }

        public void Add(ProductDO product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _dbContext.Products.Add(product);
        }

        public void Update(ProductDO product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _dbContext.Products.Update(product);
        }

        public void Remove(ProductDO product)
        {
            if (product is null)
            {
                throw new ArgumentException(nameof(product));
            }

            _dbContext.Products.Remove(product);
        }

        public async Task<bool> ExistsBySkuAsync(
            string sku,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sku))
                {
                    throw new ArgumentException("Invalid SKU provided");
                }

                return await _dbContext.Products.AnyAsync(i => i.Sku == sku, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking product by SKU : {ex.Message}");
            }
        }

        public async Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Products.AnyAsync(i => i.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking product by name : {ex.Message}");
            }
        }

        #endregion
    }
}
