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
    public sealed class AisleRepository : IAisleRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public AisleRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<AisleDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Aisles
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all aisles : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AisleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Aisles
                    .Include(e => e.RowLocs)
                    .ThenInclude(r => r.Trays)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all aisles : {ex.Message}");
            }
        }

        public async Task<AisleDO?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Aisles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching aisle by id : {ex.Message}");
            }
        }

        public async Task<AisleDO?> GetByIdToMutateAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Aisles
                    .Include(e => e.RowLocs)
                    .ThenInclude(r => r.Trays)
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching aisle by id : {ex.Message}");
            }
        }

        public async Task<AisleDO?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Aisles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching aisle by name : {ex.Message}");
            }
        }

        public async Task<AisleDO?> GetByNameToMutateAsync(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Aisles
                    .Include(e => e.RowLocs)
                    .ThenInclude(r => r.Trays)
                    .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching aisle by name : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<AisleDO>> GetByWarehouseIdAsync(int warehouseId, CancellationToken cancellationToken = default)
        {
            try
            {
                if (warehouseId == 0)
                {
                    throw new ArgumentException("Invalid warehouse id provided");
                }

                return await _dbContext.Aisles
                    .AsNoTracking()
                    .Where(e => e.WarehouseId == warehouseId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching aisles by warehouse id : {ex.Message}");
            }
        }

        public void Add(AisleDO aisle)
        {
            if (aisle is null)
            {
                throw new ArgumentNullException(nameof(aisle));
            }

            _dbContext.Aisles.Add(aisle);
        }

        public void Update(AisleDO aisle)
        {
            if (aisle is null)
            {
                throw new ArgumentNullException(nameof(aisle));
            }

            _dbContext.Aisles.Update(aisle);
        }

        public void Remove(AisleDO aisle)
        {
            if (aisle is null)
            {
                throw new ArgumentException(nameof(aisle));
            }

            _dbContext.Aisles.Remove(aisle);
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException("Invalid name provided");
                }

                return await _dbContext.Aisles.AnyAsync(i => i.Name == name, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking aisle by name : {ex.Message}");
            }
        }

        #endregion
    }
}
