using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IMaterialStorageRuleRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all material storage rules
        /// </summary>
        Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all material storage rules to make changes
        /// </summary>
        Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material storage rule by its unique identifier
        /// </summary>
        Task<MaterialStorageRuleDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a material storage rule by its unique identifier to make changes
        /// </summary>
        Task<MaterialStorageRuleDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves material storage rules by material ID
        /// </summary>
        Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetByMaterialIdAsync(
            int materialId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves material storage rules by material ID to make changes
        /// </summary>
        Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetByMaterialIdToMutateAsync(
            int materialId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves material storage rules by preferred section ID
        /// </summary>
        Task<IReadOnlyCollection<MaterialStorageRuleDO>> GetByPreferredSectionIdAsync(
            int preferredSectionId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new material storage rule
        /// </summary>
        void Add(MaterialStorageRuleDO rule);

        /// <summary>
        /// Updates a material storage rule
        /// </summary>
        void Update(MaterialStorageRuleDO rule);

        /// <summary>
        /// Removes the material storage rule
        /// </summary>
        void Remove(MaterialStorageRuleDO rule);

        /// <summary>
        /// Checks whether any material storage rule exists for the given material ID
        /// </summary>
        Task<bool> ExistsByMaterialIdAsync(
            int materialId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
