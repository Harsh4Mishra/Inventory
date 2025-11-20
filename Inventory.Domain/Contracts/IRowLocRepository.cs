using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Contracts
{
    public interface IRowLocRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all row locations by aisle id.
        /// </summary>
        Task<IReadOnlyCollection<RowLocDO>> GetAllByAisleIdAsync(
            Guid aisleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a row location by its unique identifier.
        /// </summary>
        Task<RowLocDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a row location by its unique identifier to make changes.
        /// </summary>
        Task<RowLocDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
