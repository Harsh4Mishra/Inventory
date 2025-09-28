using Inventory.Application.Contracts;

namespace Inventory.PersistenceService.Configurations
{
    public sealed class UnitOfWork
       : IUnitOfWork
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public UnitOfWork(InventoryDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        #endregion

        #region Methods

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
