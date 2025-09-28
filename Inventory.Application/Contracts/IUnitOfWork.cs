namespace Inventory.Application.Contracts
{
    public interface IUnitOfWork
    {
        #region Signatures

        public Task SaveChangesAsync(CancellationToken cancellationToken);

        #endregion
    }
}