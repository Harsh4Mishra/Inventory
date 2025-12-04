using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IEnumValueRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all enum values by enum type id
        /// </summary>
        Task<IReadOnlyCollection<EnumValueDO>> GetAllByEnumTypeIdAsync(
            int enumTypeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all enum values by enum type id to make changes
        /// </summary>
        Task<IReadOnlyCollection<EnumValueDO>> GetAllByEnumTypeIdToMutateAsync(
            int enumTypeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active enum values by enum type id
        /// </summary>
        Task<IReadOnlyCollection<EnumValueDO>> GetAllActiveByEnumTypeIdAsync(
            int enumTypeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active enum values by enum type id to make changes
        /// </summary>
        Task<IReadOnlyCollection<EnumValueDO>> GetAllActiveByEnumTypeIdToMutateAsync(
            int enumTypeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum value by its unique identifier
        /// </summary>
        Task<EnumValueDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum value by its unique identifier to make changes
        /// </summary>
        Task<EnumValueDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum value by enum type id and name
        /// </summary>
        Task<EnumValueDO?> GetByEnumTypeIdAndNameAsync(
            int enumTypeId,
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum value by enum type id and code
        /// </summary>
        Task<EnumValueDO?> GetByEnumTypeIdAndCodeAsync(
            int enumTypeId,
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any enum value exists with the given name for a specific enum type
        /// </summary>
        Task<bool> ExistsByNameAsync(
            int enumTypeId,
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any enum value exists with the given code for a specific enum type
        /// </summary>
        Task<bool> ExistsByCodeAsync(
            int enumTypeId,
            string code,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
