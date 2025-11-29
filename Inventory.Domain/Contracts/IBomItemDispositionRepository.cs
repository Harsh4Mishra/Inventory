using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IBomItemDispositionRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all bom item dispositions
        /// </summary>
        Task<IReadOnlyCollection<BomItemDispositionDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all bom item dispositions to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomItemDispositionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves dispositions by bom item id
        /// </summary>
        Task<IReadOnlyCollection<BomItemDispositionDO>> GetByBomItemIdAsync(
            Guid bomItemId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves dispositions by bom item id to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomItemDispositionDO>> GetByBomItemIdToMutateAsync(
            Guid bomItemId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a bom item disposition by its unique identifier
        /// </summary>
        Task<BomItemDispositionDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a bom item disposition by its unique identifier to make changes
        /// </summary>
        Task<BomItemDispositionDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves dispositions by disposition type
        /// </summary>
        Task<IReadOnlyCollection<BomItemDispositionDO>> GetByDispositionAsync(
            string disposition,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves dispositions by disposition type to make changes
        /// </summary>
        Task<IReadOnlyCollection<BomItemDispositionDO>> GetByDispositionToMutateAsync(
            string disposition,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new bom item disposition
        /// </summary>
        void Add(BomItemDispositionDO bomItemDisposition);

        /// <summary>
        /// Removes the bom item disposition
        /// </summary>
        void Remove(BomItemDispositionDO bomItemDisposition);

        /// <summary>
        /// Checks whether any disposition exists for the given bom item
        /// </summary>
        Task<bool> ExistsByBomItemIdAsync(
            Guid bomItemId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
