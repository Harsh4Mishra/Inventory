using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IRoleRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all roles
        /// </summary>
        Task<IReadOnlyCollection<RoleDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all roles to make changes
        /// </summary>
        Task<IReadOnlyCollection<RoleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active roles
        /// </summary>
        Task<IReadOnlyCollection<RoleDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active roles to make changes
        /// </summary>
        Task<IReadOnlyCollection<RoleDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a role by its unique identifier.
        /// </summary>
        Task<RoleDO?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a role by its unique identifier to make changes.
        /// </summary>
        Task<RoleDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an pin location by its pincode.
        /// </summary>
        Task<RoleDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an industry by its name to make changes.
        /// </summary>
        Task<RoleDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new pin location
        /// </summary>
        void Add(RoleDO role);

        /// <summary>
        /// Removes the pin location
        /// </summary>
        void Remove(RoleDO role);

        /// <summary>
        /// Checks whether any pin location exists with the given pincode.
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        #endregion
    }
}