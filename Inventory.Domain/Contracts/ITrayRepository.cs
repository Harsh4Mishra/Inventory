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
            int rowId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a tray by its unique identifier.
        /// </summary>
        Task<TrayDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a tray by its unique identifier to make changes.
        /// </summary>
        Task<TrayDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        #endregion
    }
}

