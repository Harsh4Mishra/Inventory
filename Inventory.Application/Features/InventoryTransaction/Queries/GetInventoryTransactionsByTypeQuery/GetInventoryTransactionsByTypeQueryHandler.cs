using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByTypeQuery
{
    public class GetInventoryTransactionsByTypeQueryHandler : IRequestHandler<GetInventoryTransactionsByTypeQuery, IEnumerable<GetInventoryTransactionsByTypeQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        #endregion

        #region Constructor

        public GetInventoryTransactionsByTypeQueryHandler(
            IMapper mapper,
            IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _mapper = mapper;
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetInventoryTransactionsByTypeQueryResult>> Handle(
            GetInventoryTransactionsByTypeQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate transaction type
                var validTypes = new[] { "receive", "issue", "transfer", "adjust", "allocate", "deallocate" };
                if (!validTypes.Contains(request.TransactionType.ToLower()))
                {
                    throw new InvalidOperationException($"Invalid transaction type: {request.TransactionType}");
                }

                // 2. Load transactions by type
                var transactions = await _inventoryTransactionRepository.GetByTransactionTypeAsync(
                    request.TransactionType, cancellationToken);

                // 3. Project to the query result and return
                return _mapper.Map<IEnumerable<GetInventoryTransactionsByTypeQueryResult>>(transactions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve inventory transactions by type: {ex.Message}");
            }
        }

        #endregion
    }
}
