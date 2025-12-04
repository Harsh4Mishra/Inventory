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
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user-role assignment by its unique identifier to make changes (including inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetByIdToMutateAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active user-role assignment by its unique identifier (excluding inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetActiveByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments by user ID (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetByUserIdAsync(
            int userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments by user ID to make changes (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetByUserIdToMutateAsync(
            int userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active user-role assignments by user ID (excluding inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetActiveByUserIdAsync(
            int userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments by role ID (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetByRoleIdAsync(
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves user-role assignments by role ID to make changes (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetByRoleIdToMutateAsync(
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active user-role assignments by role ID (excluding inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<UserRoleDO>> GetActiveByRoleIdAsync(
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user-role assignment by user ID and role ID (including inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetByUserAndRoleAsync(
            int userId,
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user-role assignment by user ID and role ID to make changes (including inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetByUserAndRoleToMutateAsync(
            int userId,
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active user-role assignment by user ID and role ID (excluding inactive and deleted)
        /// </summary>
        Task<UserRoleDO?> GetActiveByUserAndRoleAsync(
            int userId,
            int roleId,
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
            int userId,
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active user-role assignment exists with the given user ID and role ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByUserAndRoleAsync(
            int userId,
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any user-role assignment exists with the given user ID (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByUserIdAsync(
            int userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active user-role assignment exists with the given user ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByUserIdAsync(
            int userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any user-role assignment exists with the given role ID (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByRoleIdAsync(
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active user-role assignment exists with the given role ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByRoleIdAsync(
            int roleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any user-role assignment exists with the given ID (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active user-role assignment exists with the given ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
