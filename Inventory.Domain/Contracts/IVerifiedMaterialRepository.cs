using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IVerifiedMaterialRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all verified materials
        /// </summary>
        Task<IReadOnlyCollection<VerifiedMaterialDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all verified materials to make changes
        /// </summary>
        Task<IReadOnlyCollection<VerifiedMaterialDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves verified materials by material batch ID
        /// </summary>
        Task<IReadOnlyCollection<VerifiedMaterialDO>> GetByMaterialBatchIdAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves verified materials by material batch ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<VerifiedMaterialDO>> GetByMaterialBatchIdToMutateAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves verified materials by employee ID (verifier)
        /// </summary>
        Task<IReadOnlyCollection<VerifiedMaterialDO>> GetByEmpIdAsync(
            Guid empId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves non-allotted verified materials
        /// </summary>
        Task<IReadOnlyCollection<VerifiedMaterialDO>> GetNonAllottedAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves qualified verified materials
        /// </summary>
        Task<IReadOnlyCollection<VerifiedMaterialDO>> GetQualifiedAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a verified material by its unique identifier
        /// </summary>
        Task<VerifiedMaterialDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a verified material by its unique identifier to make changes
        /// </summary>
        Task<VerifiedMaterialDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new verified material
        /// </summary>
        void Add(VerifiedMaterialDO verifiedMaterial);

        /// <summary>
        /// Removes the verified material
        /// </summary>
        void Remove(VerifiedMaterialDO verifiedMaterial);

        /// <summary>
        /// Checks whether any verified material exists for the given material batch ID
        /// </summary>
        Task<bool> ExistsByMaterialBatchIdAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total quantity of verified materials for a specific material batch
        /// </summary>
        Task<decimal> GetTotalQuantityByMaterialBatchIdAsync(
            Guid materialBatchId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
