using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IAppModuleRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all app modules
        /// </summary>
        Task<IReadOnlyCollection<AppModuleDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all app modules to make changes
        /// </summary>
        Task<IReadOnlyCollection<AppModuleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active app modules
        /// </summary>
        Task<IReadOnlyCollection<AppModuleDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active app modules to make changes
        /// </summary>
        Task<IReadOnlyCollection<AppModuleDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an app module by its unique identifier.
        /// </summary>
        Task<AppModuleDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an app module by its unique identifier to make changes.
        /// </summary>
        Task<AppModuleDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active app module by its unique identifier.
        /// </summary>
        Task<AppModuleDO?> GetActiveByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an app module by its code.
        /// </summary>
        Task<AppModuleDO?> GetByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an app module by its code to make changes.
        /// </summary>
        Task<AppModuleDO?> GetByCodeToMutateAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active app module by its code.
        /// </summary>
        Task<AppModuleDO?> GetActiveByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves app modules by tenant ID.
        /// </summary>
        Task<IReadOnlyCollection<AppModuleDO>> GetByTenantIdAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves app modules by tenant ID to make changes.
        /// </summary>
        Task<IReadOnlyCollection<AppModuleDO>> GetByTenantIdToMutateAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves active app modules by tenant ID.
        /// </summary>
        Task<IReadOnlyCollection<AppModuleDO>> GetActiveByTenantIdAsync(
            Guid tenantId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an app module by tenant ID and code.
        /// </summary>
        Task<AppModuleDO?> GetByTenantAndCodeAsync(
            Guid tenantId,
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an app module by tenant ID and code to make changes.
        /// </summary>
        Task<AppModuleDO?> GetByTenantAndCodeToMutateAsync(
            Guid tenantId,
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an active app module by tenant ID and code.
        /// </summary>
        Task<AppModuleDO?> GetActiveByTenantAndCodeAsync(
            Guid tenantId,
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new app module
        /// </summary>
        void Add(AppModuleDO appModule);

        /// <summary>
        /// Updates an existing app module
        /// </summary>
        void Update(AppModuleDO appModule);

        /// <summary>
        /// Removes an app module
        /// </summary>
        void Remove(AppModuleDO appModule);

        /// <summary>
        /// Checks whether any app module exists with the given code.
        /// </summary>
        Task<bool> ExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active app module exists with the given code.
        /// </summary>
        Task<bool> ActiveExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any app module exists with the given tenant ID and code.
        /// </summary>
        Task<bool> ExistsByTenantAndCodeAsync(
            Guid tenantId,
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active app module exists with the given tenant ID and code.
        /// </summary>
        Task<bool> ActiveExistsByTenantAndCodeAsync(
            Guid tenantId,
            string code,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any app module exists with the given ID.
        /// </summary>
        Task<bool> ExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any active app module exists with the given ID.
        /// </summary>
        Task<bool> ActiveExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
