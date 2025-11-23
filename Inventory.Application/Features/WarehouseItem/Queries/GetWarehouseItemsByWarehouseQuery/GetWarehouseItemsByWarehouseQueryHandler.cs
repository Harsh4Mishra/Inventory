using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByWarehouseQuery
{
    public class GetWarehouseItemsByWarehouseQueryHandler : IRequestHandler<GetWarehouseItemsByWarehouseQuery, IEnumerable<GetWarehouseItemsByWarehouseQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseItemRepository _warehouseItemRepository;

        #endregion

        #region Constructor

        public GetWarehouseItemsByWarehouseQueryHandler(
            IMapper mapper,
            IWarehouseItemRepository warehouseItemRepository)
        {
            _mapper = mapper;
            _warehouseItemRepository = warehouseItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetWarehouseItemsByWarehouseQueryResult>> Handle(
            GetWarehouseItemsByWarehouseQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load warehouse items by warehouse ID
                var warehouseItems = await _warehouseItemRepository.GetByWarehouseIdAsync(request.WarehouseId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetWarehouseItemsByWarehouseQueryResult>>(warehouseItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve warehouse items for warehouse '{request.WarehouseId}': {ex.Message}");
            }
        }

        #endregion
    }
}
