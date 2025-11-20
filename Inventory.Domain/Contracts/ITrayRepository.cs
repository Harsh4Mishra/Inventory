using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface ITrayRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all trays by row location id.
        /// </summary>
        Task<IReadOnlyCollection<TrayDO>> GetAllByRowIdAsync(
            Guid rowId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a tray by its unique identifier.
        /// </summary>
        Task<TrayDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a tray by its unique identifier to make changes.
        /// </summary>
        Task<TrayDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        #endregion
    }
}

