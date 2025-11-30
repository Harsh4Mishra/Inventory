using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsQuery
{
    public class GetInventoryTransactionsQueryHandler : IRequestHandler<GetInventoryTransactionsQuery, IEnumerable<GetInventoryTransactionsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        #endregion

        #region Constructor

        public GetInventoryTransactionsQueryHandler(
            IMapper mapper,
            IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _mapper = mapper;
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetInventoryTransactionsQueryResult>> Handle(
            GetInventoryTransactionsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all inventory transactions
                var transactions = await _inventoryTransactionRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetInventoryTransactionsQueryResult>>(transactions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve inventory transactions: {ex.Message}");
            }
        }

        #endregion
    }
}
