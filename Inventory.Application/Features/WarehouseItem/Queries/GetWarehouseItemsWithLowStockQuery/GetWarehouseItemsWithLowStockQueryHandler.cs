using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsWithLowStockQuery
{
    public class GetWarehouseItemsWithLowStockQueryHandler : IRequestHandler<GetWarehouseItemsWithLowStockQuery, IEnumerable<GetWarehouseItemsWithLowStockQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseItemRepository _warehouseItemRepository;

        #endregion

        #region Constructor

        public GetWarehouseItemsWithLowStockQueryHandler(
            IMapper mapper,
            IWarehouseItemRepository warehouseItemRepository)
        {
            _mapper = mapper;
            _warehouseItemRepository = warehouseItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetWarehouseItemsWithLowStockQueryResult>> Handle(
            GetWarehouseItemsWithLowStockQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all warehouse items
                var warehouseItems = await _warehouseItemRepository.GetAllAsync(cancellationToken);

                // 2. Filter items with quantity below threshold
                var lowStockItems = warehouseItems.Where(item => item.Quantity <= request.Threshold);

                // 3. Project to the query result and return
                return _mapper.Map<IEnumerable<GetWarehouseItemsWithLowStockQueryResult>>(lowStockItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve low stock warehouse items: {ex.Message}");
            }
        }

        #endregion
    }
}
