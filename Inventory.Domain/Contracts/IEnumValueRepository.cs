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
            Guid enumTypeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all enum values by enum type id to make changes
        /// </summary>
        Task<IReadOnlyCollection<EnumValueDO>> GetAllByEnumTypeIdToMutateAsync(
            Guid enumTypeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active enum values by enum type id
        /// </summary>
        Task<IReadOnlyCollection<EnumValueDO>> GetAllActiveByEnumTypeIdAsync(
            Guid enumTypeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active enum values by enum type id to make changes
        /// </summary>
        Task<IReadOnlyCollection<EnumValueDO>> GetAllActiveByEnumTypeIdToMutateAsync(
            Guid enumTypeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum value by its unique identifier
        /// </summary>
        Task<EnumValueDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum value by its unique identifier to make changes
        /// </summary>
        Task<EnumValueDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum value by enum type id and name
        /// </summary>
        Task<EnumValueDO?> GetByEnumTypeIdAndNameAsync(
            Guid enumTypeId,
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum value by enum type id and code
        /// </summary>
        Task<EnumValueDO?> GetByEnumTypeIdAndCodeAsync(
            Guid enumTypeId,
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any enum value exists with the given name for a specific enum type
        /// </summary>
        Task<bool> ExistsByNameAsync(
            Guid enumTypeId,
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any enum value exists with the given code for a specific enum type
        /// </summary>
        Task<bool> ExistsByCodeAsync(
            Guid enumTypeId,
            string code,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
