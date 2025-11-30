using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByDateRangeQuery
{
    public class GetInventoryTransactionsByDateRangeQueryHandler : IRequestHandler<GetInventoryTransactionsByDateRangeQuery, IEnumerable<GetInventoryTransactionsByDateRangeQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        #endregion

        #region Constructor

        public GetInventoryTransactionsByDateRangeQueryHandler(
            IMapper mapper,
            IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _mapper = mapper;
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetInventoryTransactionsByDateRangeQueryResult>> Handle(
            GetInventoryTransactionsByDateRangeQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate date range
                if (request.StartDate > request.EndDate)
                {
                    throw new InvalidOperationException("Start date cannot be after end date.");
                }

                // 2. Load transactions within date range
                var transactions = await _inventoryTransactionRepository.GetByDateRangeAsync(
                    request.StartDate, request.EndDate, cancellationToken);

                // 3. Project to the query result and return
                return _mapper.Map<IEnumerable<GetInventoryTransactionsByDateRangeQueryResult>>(transactions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve inventory transactions for date range: {ex.Message}");
            }
        }

        #endregion
    }
}
