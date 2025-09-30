using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IUserRoleRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all user-role assignments (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all user-role assignments to make changes (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active user-role assignments (excluding inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active user-role assignments to make changes (excluding inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments that are not soft deleted
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetAllUndeletedAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments that are not soft deleted to make changes
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetAllUndeletedToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user-role assignment by its unique identifier (including inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user-role assignment by its unique identifier to make changes (including inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active user-role assignment by its unique identifier (excluding inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetActiveByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments by user ID (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments by user ID to make changes (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetByUserIdToMutateAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active user-role assignments by user ID (excluding inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetActiveByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments by role ID (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments by role ID to make changes (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetByRoleIdToMutateAsync(
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active user-role assignments by role ID (excluding inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetActiveByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user-role assignment by user ID and role ID (including inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetByUserAndRoleAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user-role assignment by user ID and role ID to make changes (including inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetByUserAndRoleToMutateAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active user-role assignment by user ID and role ID (excluding inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetActiveByUserAndRoleAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new user-role assignment
        /// </summary>
        void Add(UserRoleDO userRole);

        /// <summary>
        /// Updates an existing user-role assignment
        /// </summary>
        void Update(UserRoleDO userRole);

        /// <summary>
        /// Soft deletes a user-role assignment
        /// </summary>
        void Remove(UserRoleDO userRole);

        /// <summary>
        /// Checks whether any user-role assignment exists with the given user ID and role ID (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByUserAndRoleAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active user-role assignment exists with the given user ID and role ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByUserAndRoleAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any user-role assignment exists with the given user ID (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active user-role assignment exists with the given user ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any user-role assignment exists with the given role ID (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active user-role assignment exists with the given role ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any user-role assignment exists with the given ID (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active user-role assignment exists with the given ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
