using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByProductQuery
{
    public class GetInventoryTransactionsByProductQueryHandler : IRequestHandler<GetInventoryTransactionsByProductQuery, IEnumerable<GetInventoryTransactionsByProductQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        #endregion

        #region Constructor

        public GetInventoryTransactionsByProductQueryHandler(
            IMapper mapper,
            IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _mapper = mapper;
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetInventoryTransactionsByProductQueryResult>> Handle(
            GetInventoryTransactionsByProductQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load transactions by product ID
                var transactions = await _inventoryTransactionRepository.GetByProductIdAsync(
                    request.ProductId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetInventoryTransactionsByProductQueryResult>>(transactions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve inventory transactions for product: {ex.Message}");
            }
        }

        #endregion
    }
}
