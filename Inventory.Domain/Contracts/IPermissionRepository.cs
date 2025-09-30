using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IPermissionRepository
    {
        #region Signatures

        Task<IReadOnlyCollection<PermissionDO>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<PermissionDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<PermissionDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<PermissionDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        Task<PermissionDO?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetByIdToMutateAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetActiveByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<PermissionDO?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetByCodeToMutateAsync(string code, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<PermissionDO>> GetByTenantIdAsync(Guid tenantId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<PermissionDO>> GetByTenantIdToMutateAsync(Guid tenantId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<PermissionDO>> GetActiveByTenantIdAsync(Guid tenantId, CancellationToken cancellationToken = default);

        Task<PermissionDO?> GetByTenantAndCodeAsync(Guid tenantId, string code, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetByTenantAndCodeToMutateAsync(Guid tenantId, string code, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetActiveByTenantAndCodeAsync(Guid tenantId, string code, CancellationToken cancellationToken = default);

        void Add(PermissionDO permission);
        void Update(PermissionDO permission);
        void Remove(PermissionDO permission);

        Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<bool> ExistsByTenantAndCodeAsync(Guid tenantId, string code, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByTenantAndCodeAsync(Guid tenantId, string code, CancellationToken cancellationToken = default);
        Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        #endregion
    }
}
