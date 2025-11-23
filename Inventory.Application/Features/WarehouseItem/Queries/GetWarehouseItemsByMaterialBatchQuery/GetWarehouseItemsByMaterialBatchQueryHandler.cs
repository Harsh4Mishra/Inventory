using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByMaterialBatchQuery
{
    public class GetWarehouseItemsByMaterialBatchQueryHandler : IRequestHandler<GetWarehouseItemsByMaterialBatchQuery, IEnumerable<GetWarehouseItemsByMaterialBatchQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseItemRepository _warehouseItemRepository;

        #endregion

        #region Constructor

        public GetWarehouseItemsByMaterialBatchQueryHandler(
            IMapper mapper,
            IWarehouseItemRepository warehouseItemRepository)
        {
            _mapper = mapper;
            _warehouseItemRepository = warehouseItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetWarehouseItemsByMaterialBatchQueryResult>> Handle(
            GetWarehouseItemsByMaterialBatchQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load warehouse items by material batch ID
                var warehouseItems = await _warehouseItemRepository.GetByMaterialBatchIdAsync(request.MaterialBatchId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetWarehouseItemsByMaterialBatchQueryResult>>(warehouseItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve warehouse items for material batch '{request.MaterialBatchId}': {ex.Message}");
            }
        }

        #endregion
    }
}
