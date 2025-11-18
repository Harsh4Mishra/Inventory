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
    public sealed class MaterialRepository
    : IMaterialRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public MaterialRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<MaterialDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Materials
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Materials : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Materials
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Materials : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Materials
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Materials : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<MaterialDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Materials
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Materials : {ex.Message}");
            }
        }

        public async Task<MaterialDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Materials
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material by id : {ex.Message}");
            }
        }

        public async Task<MaterialDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Materials
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material by id : {ex.Message}");
            }
        }

        public async Task<MaterialDO?> GetBySkuAsync(
            string sku,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sku))
                {
                    throw new ArgumentException("Invalid SKU provided");
                }

                return await _dbContext.Materials
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Sku == sku.Trim().ToUpper(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material by SKU : {ex.Message}");
            }
        }

        public async Task<MaterialDO?> GetBySkuToMutateAsync(
            string sku,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sku))
                {
                    throw new ArgumentException("Invalid SKU provided");
                }

                return await _dbContext.Materials
                    .FirstOrDefaultAsync(e => e.Sku == sku.Trim().ToUpper(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material by SKU : {ex.Message}");
            }
        }

        public async Task<MaterialDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Materials
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Name == name.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material by name : {ex.Message}");
            }
        }

        public async Task<MaterialDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name provided");
                }

                return await _dbContext.Materials
                    .FirstOrDefaultAsync(e => e.Name == name.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material by name : {ex.Message}");
            }
        }

        public async Task<MaterialDO?> GetByCasNumberAsync(
            string casNumber,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(casNumber))
                {
                    throw new ArgumentException("Invalid CAS number provided");
                }

                return await _dbContext.Materials
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.CasNumber == casNumber.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material by CAS number : {ex.Message}");
            }
        }

        public async Task<MaterialDO?> GetByCasNumberToMutateAsync(
            string casNumber,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(casNumber))
                {
                    throw new ArgumentException("Invalid CAS number provided");
                }

                return await _dbContext.Materials
                    .FirstOrDefaultAsync(e => e.CasNumber == casNumber.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching material by CAS number : {ex.Message}");
            }
        }

        public void Add(MaterialDO material)
        {
            if (material is null)
            {
                throw new ArgumentNullException(nameof(material));
            }

            _dbContext.Materials.Add(material);
        }

        public void Update(MaterialDO material)
        {
            if (material is null)
            {
                throw new ArgumentNullException(nameof(material));
            }

            _dbContext.Materials.Update(material);
        }

        public void Remove(MaterialDO material)
        {
            if (material is null)
            {
                throw new ArgumentException(nameof(material));
            }

            _dbContext.Materials.Remove(material);
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

                return await _dbContext.Materials.AnyAsync(i => i.Sku == sku.Trim().ToUpper(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking material by SKU : {ex.Message}");
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

                return await _dbContext.Materials.AnyAsync(i => i.Name == name.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking material by name : {ex.Message}");
            }
        }

        public async Task<bool> ExistsByCasNumberAsync(
            string casNumber,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(casNumber))
                {
                    throw new ArgumentException("Invalid CAS number provided");
                }

                return await _dbContext.Materials.AnyAsync(i => i.CasNumber == casNumber.Trim(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking material by CAS number : {ex.Message}");
            }
        }

        #endregion
    }
}
