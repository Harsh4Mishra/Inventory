using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemByIdQuery
{
    public class GetWarehouseItemByIdQueryHandler : IRequestHandler<GetWarehouseItemByIdQuery, GetWarehouseItemByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseItemRepository _warehouseItemRepository;

        #endregion

        #region Constructor

        public GetWarehouseItemByIdQueryHandler(
            IMapper mapper,
            IWarehouseItemRepository warehouseItemRepository)
        {
            _mapper = mapper;
            _warehouseItemRepository = warehouseItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetWarehouseItemByIdQueryResult?> Handle(
            GetWarehouseItemByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load warehouse item by ID
                var warehouseItem = await _warehouseItemRepository.GetByIdAsync(request.Id, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<GetWarehouseItemByIdQueryResult?>(warehouseItem);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve warehouse item '{request.Id}': {ex.Message}");
            }
        }

        #endregion
    }
}
