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
    public sealed class VendorRepository
    : IVendorRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public VendorRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<VendorDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Vendors
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Vendors : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VendorDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Vendors
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Vendors : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VendorDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Vendors
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Vendors : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VendorDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Vendors
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Vendors : {ex.Message}");
            }
        }

        public async Task<VendorDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Vendors
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching vendor by id : {ex.Message}");
            }
        }

        public async Task<VendorDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Vendors
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching vendor by id : {ex.Message}");
            }
        }

        public async Task<VendorDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Vendors
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching vendor by name : {ex.Message}");
            }
        }

        public async Task<VendorDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Vendors
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching vendor by name : {ex.Message}");
            }
        }

        public async Task<VendorDO?> GetByContactAsync(
            string contact,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (contact is null)
                {
                    throw new ArgumentNullException("Invalid contact provided");
                }

                return await _dbContext.Vendors
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Contact == contact, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching vendor by contact : {ex.Message}");
            }
        }

        public async Task<VendorDO?> GetByContactToMutateAsync(
            string contact,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (contact is null)
                {
                    throw new ArgumentNullException("Invalid contact provided");
                }

                return await _dbContext.Vendors
                    .FirstOrDefaultAsync(e => e.Contact == contact, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching vendor by contact : {ex.Message}");
            }
        }

        public void Add(VendorDO vendor)
        {
            if (vendor is null)
            {
                throw new ArgumentNullException(nameof(vendor));
            }

            _dbContext.Vendors.Add(vendor);
        }

        public void Update(VendorDO vendor)
        {
            if (vendor is null)
            {
                throw new ArgumentNullException(nameof(vendor));
            }

            _dbContext.Vendors.Update(vendor);
        }

        public void Remove(VendorDO vendor)
        {
            if (vendor is null)
            {
                throw new ArgumentException(nameof(vendor));
            }

            _dbContext.Vendors.Remove(vendor);
        }

        public async Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Vendors.AnyAsync(i => i.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking vendor by name : {ex.Message}");
            }
        }

        public async Task<bool> ExistsByContactAsync(
            string contact,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (contact is null)
                {
                    throw new ArgumentNullException("Invalid contact provided");
                }

                return await _dbContext.Vendors.AnyAsync(i => i.Contact == contact, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking vendor by contact : {ex.Message}");
            }
        }

        #endregion
    }
}
