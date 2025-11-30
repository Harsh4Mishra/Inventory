using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionByUUIDQuery
{
    public class GetInventoryTransactionByUUIDQueryHandler : IRequestHandler<GetInventoryTransactionByUUIDQuery, GetInventoryTransactionByUUIDQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        #endregion

        #region Constructor

        public GetInventoryTransactionByUUIDQueryHandler(
            IMapper mapper,
            IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _mapper = mapper;
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetInventoryTransactionByUUIDQueryResult?> Handle(
            GetInventoryTransactionByUUIDQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load transaction by UUID
                var transaction = await _inventoryTransactionRepository.GetByUUIDAsync(
                    request.UUID, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<GetInventoryTransactionByUUIDQueryResult?>(transaction);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve inventory transaction: {ex.Message}");
            }
        }

        #endregion
    }
}
