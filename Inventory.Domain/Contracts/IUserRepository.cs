using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IUserRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all users
        /// </summary>
        Task<IReadOnlyCollection<UserDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all users to make changes
        /// </summary>
        Task<IReadOnlyCollection<UserDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active users
        /// </summary>
        Task<IReadOnlyCollection<UserDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active users to make changes
        /// </summary>
        Task<IReadOnlyCollection<UserDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user by its unique identifier.
        /// </summary>
        Task<UserDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user by its unique identifier to make changes.
        /// </summary>
        Task<UserDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user by its mobile number to make changes.
        /// </summary>
        Task<UserDO?> GetByMobileNumberToMutateAsync(
            string mobileNumber,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a user by its email to make changes.
        /// </summary>
        Task<UserDO?> GetByEmailToMutateAsync(
            string emailId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an pin location by its pincode.
        /// </summary>
        //Task<UserDO?> GetByNameAsync(
        //    string name,
        //    CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an industry by its name to make changes.
        /// </summary>
        //Task<UserDO?> GetByNameToMutateAsync(
        //    string name,
        //    CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new pin location
        /// </summary>
        void Add(UserDO user);

        /// <summary>
        /// Removes the pin location
        /// </summary>
        void Remove(UserDO user);

        /// <summary>
        /// Checks whether any pin location exists with the given pincode.
        /// </summary>
        Task<bool> ExistsByMobileNumberAsync(
            string mobileNumber,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any user exists with the given emailid.
        /// </summary>
        Task<bool> ExistsByEmailAsync(
            string emailid,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
