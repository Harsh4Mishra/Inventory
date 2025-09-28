using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IOrganizationRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all organizations (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<OrganizationDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all organizations to make changes (including inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<OrganizationDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active organizations (excluding inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<OrganizationDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active organizations to make changes (excluding inactive and deleted)
        /// </summary>
        Task<IReadOnlyCollection<OrganizationDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves organizations that are not soft deleted
        /// </summary>
        Task<IReadOnlyCollection<OrganizationDO>> GetAllUndeletedAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves organizations that are not soft deleted to make changes
        /// </summary>
        Task<IReadOnlyCollection<OrganizationDO>> GetAllUndeletedToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an organization by its unique identifier (including inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an organization by its unique identifier to make changes (including inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active organization by its unique identifier (excluding inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetActiveByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an organization by its name (including inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an organization by its name to make changes (including inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active organization by its name (excluding inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetActiveByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an organization by its code (including inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an organization by its code to make changes (including inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetByCodeToMutateAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active organization by its code (excluding inactive and deleted)
        /// </summary>
        Task<OrganizationDO?> GetActiveByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new organization
        /// </summary>
        void Add(OrganizationDO organization);

        /// <summary>
        /// Updates an existing organization
        /// </summary>
        void Update(OrganizationDO organization);

        /// <summary>
        /// Soft deletes an organization
        /// </summary>
        void SoftDelete(OrganizationDO organization);

        /// <summary>
        /// Checks whether any organization exists with the given name (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active organization exists with the given name (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any organization exists with the given code (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active organization exists with the given code (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any organization exists with the given ID (including inactive and deleted)
        /// </summary>
        Task<bool> ExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active organization exists with the given ID (excluding inactive and deleted)
        /// </summary>
        Task<bool> ActiveExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
