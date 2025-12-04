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

        Task<PermissionDO?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetByIdToMutateAsync(int id, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetActiveByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<PermissionDO?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetByCodeToMutateAsync(string code, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<PermissionDO>> GetByTenantIdAsync(int tenantId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<PermissionDO>> GetByTenantIdToMutateAsync(int tenantId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<PermissionDO>> GetActiveByTenantIdAsync(int tenantId, CancellationToken cancellationToken = default);

        Task<PermissionDO?> GetByTenantAndCodeAsync(int tenantId, string code, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetByTenantAndCodeToMutateAsync(int tenantId, string code, CancellationToken cancellationToken = default);
        Task<PermissionDO?> GetActiveByTenantAndCodeAsync(int tenantId, string code, CancellationToken cancellationToken = default);

        void Add(PermissionDO permission);
        void Update(PermissionDO permission);
        void Remove(PermissionDO permission);

        Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<bool> ExistsByTenantAndCodeAsync(int tenantId, string code, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByTenantAndCodeAsync(int tenantId, string code, CancellationToken cancellationToken = default);
        Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> ActiveExistsByIdAsync(int id, CancellationToken cancellationToken = default);

        #endregion
    }
}
