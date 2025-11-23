using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByLocationQuery
{
    public class GetWarehouseItemsByLocationQueryHandler : IRequestHandler<GetWarehouseItemsByLocationQuery, IEnumerable<GetWarehouseItemsByLocationQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseItemRepository _warehouseItemRepository;

        #endregion

        #region Constructor

        public GetWarehouseItemsByLocationQueryHandler(
            IMapper mapper,
            IWarehouseItemRepository warehouseItemRepository)
        {
            _mapper = mapper;
            _warehouseItemRepository = warehouseItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetWarehouseItemsByLocationQueryResult>> Handle(
            GetWarehouseItemsByLocationQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load warehouse items by location
                var warehouseItems = await _warehouseItemRepository.GetByLocationAsync(
                    request.WarehouseId,
                    request.AisleId,
                    request.RowId,
                    request.TrayId,
                    cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetWarehouseItemsByLocationQueryResult>>(warehouseItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve warehouse items for location: {ex.Message}");
            }
        }

        #endregion
    }
}
