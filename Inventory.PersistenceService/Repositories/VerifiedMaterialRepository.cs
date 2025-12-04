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
    public sealed class VerifiedMaterialRepository : IVerifiedMaterialRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public VerifiedMaterialRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.VerifiedMaterials
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all verified materials : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.VerifiedMaterials
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all verified materials : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.VerifiedMaterials
                    .AsNoTracking()
                    //.Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active verified materials : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.VerifiedMaterials
                    //.Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active verified materials : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == 0)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.VerifiedMaterials
                    .AsNoTracking()
                    .Where(e => e.MaterialBatchId == materialBatchId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching verified materials by batch id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetByMaterialBatchIdToMutateAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == 0)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.VerifiedMaterials
                    .Where(e => e.MaterialBatchId == materialBatchId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching verified materials by batch id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetByEmpIdAsync(
            int empId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (empId == 0)
                {
                    throw new ArgumentException("Invalid employee id provided");
                }

                return await _dbContext.VerifiedMaterials
                    .AsNoTracking()
                    .Where(e => e.EmpId == empId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching verified materials by employee id : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetNonAllottedAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.VerifiedMaterials
                    .AsNoTracking()
                    .Where(e => !e.IsAllotted)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching non-allotted verified materials : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<VerifiedMaterialDO>> GetQualifiedAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.VerifiedMaterials
                    .AsNoTracking()
                    .Where(e => e.IsQualified == true)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching qualified verified materials : {ex.Message}");
            }
        }

        public async Task<VerifiedMaterialDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.VerifiedMaterials
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching verified material by id : {ex.Message}");
            }
        }

        public async Task<VerifiedMaterialDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.VerifiedMaterials
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching verified material by id : {ex.Message}");
            }
        }

        public void Add(VerifiedMaterialDO verifiedMaterial)
        {
            if (verifiedMaterial is null)
            {
                throw new ArgumentNullException(nameof(verifiedMaterial));
            }

            _dbContext.VerifiedMaterials.Add(verifiedMaterial);
        }

        public void Remove(VerifiedMaterialDO verifiedMaterial)
        {
            if (verifiedMaterial is null)
            {
                throw new ArgumentException(nameof(verifiedMaterial));
            }

            _dbContext.VerifiedMaterials.Remove(verifiedMaterial);
        }

        public async Task<bool> ExistsByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == 0)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.VerifiedMaterials.AnyAsync(i => i.MaterialBatchId == materialBatchId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking verified material by batch id : {ex.Message}");
            }
        }

        public async Task<decimal> GetTotalQuantityByMaterialBatchIdAsync(
            int materialBatchId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (materialBatchId == 0)
                {
                    throw new ArgumentException("Invalid material batch id provided");
                }

                return await _dbContext.VerifiedMaterials
                    .Where(e => e.MaterialBatchId == materialBatchId)
                    .SumAsync(e => e.Quantity, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while calculating total quantity by batch id : {ex.Message}");
            }
        }

        #endregion
    }
}
