using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetStockLevelQuery
{
    public class GetStockLevelQueryHandler : IRequestHandler<GetStockLevelQuery, decimal>
    {
        #region Fields

        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        #endregion

        #region Constructor

        public GetStockLevelQueryHandler(IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<decimal> Handle(
            GetStockLevelQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.MaterialBatchId.HasValue)
                {
                    return await _inventoryTransactionRepository.GetCurrentStockByMaterialBatchAsync(
                        request.MaterialBatchId.Value, cancellationToken);
                }
                else if (request.ProductId.HasValue)
                {
                    return await _inventoryTransactionRepository.GetCurrentStockByProductAsync(
                        request.ProductId.Value, cancellationToken);
                }
                else
                {
                    throw new InvalidOperationException("Either MaterialBatchId or ProductId must be provided.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve stock level: {ex.Message}");
            }
        }

        #endregion
    }
}
