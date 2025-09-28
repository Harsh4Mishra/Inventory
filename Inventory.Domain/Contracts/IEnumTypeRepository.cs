

using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IEnumTypeRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all enum types
        /// </summary>
        Task<IReadOnlyCollection<EnumTypeDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all enum types to make changes
        /// </summary>
        Task<IReadOnlyCollection<EnumTypeDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active enum types
        /// </summary>
        Task<IReadOnlyCollection<EnumTypeDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active enum types to make changes
        /// </summary>
        Task<IReadOnlyCollection<EnumTypeDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum type by its unique identifier
        /// </summary>
        Task<EnumTypeDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum type by its unique identifier to make changes
        /// </summary>
        Task<EnumTypeDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum type by its name
        /// </summary>
        Task<EnumTypeDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum type by its name to make changes
        /// </summary>
        Task<EnumTypeDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum type by its code
        /// </summary>
        Task<EnumTypeDO?> GetByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an enum type by its code to make changes
        /// </summary>
        Task<EnumTypeDO?> GetByCodeToMutateAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new enum type
        /// </summary>
        void Add(EnumTypeDO enumType);

        /// <summary>
        /// Removes the enum type
        /// </summary>
        void Remove(EnumTypeDO enumType);

        /// <summary>
        /// Checks whether any enum type exists with the given name
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any enum type exists with the given code
        /// </summary>
        Task<bool> ExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
