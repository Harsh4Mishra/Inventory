using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByMaterialBatchQuery
{
    public class GetInventoryTransactionsByMaterialBatchQueryHandler : IRequestHandler<GetInventoryTransactionsByMaterialBatchQuery, IEnumerable<GetInventoryTransactionsByMaterialBatchQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        #endregion

        #region Constructor

        public GetInventoryTransactionsByMaterialBatchQueryHandler(
            IMapper mapper,
            IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _mapper = mapper;
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetInventoryTransactionsByMaterialBatchQueryResult>> Handle(
            GetInventoryTransactionsByMaterialBatchQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load transactions by material batch ID
                var transactions = await _inventoryTransactionRepository.GetByMaterialBatchIdAsync(
                    request.MaterialBatchId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetInventoryTransactionsByMaterialBatchQueryResult>>(transactions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve inventory transactions for material batch: {ex.Message}");
            }
        }

        #endregion
    }
}
