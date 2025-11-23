using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsQuery
{
    public class GetWarehouseItemsQueryHandler : IRequestHandler<GetWarehouseItemsQuery, IEnumerable<GetWarehouseItemsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseItemRepository _warehouseItemRepository;

        #endregion

        #region Constructor

        public GetWarehouseItemsQueryHandler(
            IMapper mapper,
            IWarehouseItemRepository warehouseItemRepository)
        {
            _mapper = mapper;
            _warehouseItemRepository = warehouseItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetWarehouseItemsQueryResult>> Handle(
            GetWarehouseItemsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all warehouse items
                var warehouseItems = await _warehouseItemRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetWarehouseItemsQueryResult>>(warehouseItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve warehouse items: {ex.Message}");
            }
        }

        #endregion
    }
}
