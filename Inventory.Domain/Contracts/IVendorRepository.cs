using Inventory.Domain.DomainObjects;

namespace Inventory.Domain.Contracts
{
    public interface IVendorRepository
    {
        #region Signatures

        /// <summary>
        /// Retrieves all vendors
        /// </summary>
        Task<IReadOnlyCollection<VendorDO>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all vendors to make changes
        /// </summary>
        Task<IReadOnlyCollection<VendorDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active vendors
        /// </summary>
        Task<IReadOnlyCollection<VendorDO>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only active vendors to make changes
        /// </summary>
        Task<IReadOnlyCollection<VendorDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a vendor by its unique identifier.
        /// </summary>
        Task<VendorDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a vendor by its unique identifier to make changes.
        /// </summary>
        Task<VendorDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a vendor by its name.
        /// </summary>
        Task<VendorDO?> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a vendor by its name to make changes.
        /// </summary>
        Task<VendorDO?> GetByNameToMutateAsync(
            string name,
            CancellationToken cancellationToken = default);

        Task<VendorDO?> GetByContactAsync(string contact, CancellationToken cancellationToken = default);
        Task<VendorDO?> GetByContactToMutateAsync(string contact, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new vendor
        /// </summary>
        void Add(VendorDO vendor);

        /// <summary>
        /// Removes the vendor
        /// </summary>
        void Remove(VendorDO vendor);

        /// <summary>
        /// Checks whether any vendor exists with the given name.
        /// </summary>
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
