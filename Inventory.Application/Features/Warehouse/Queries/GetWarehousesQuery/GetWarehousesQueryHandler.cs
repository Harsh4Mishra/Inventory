using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Queries.GetWarehousesQuery
{
    public class GetWarehousesQueryHandler : IRequestHandler<GetWarehousesQuery, IEnumerable<GetWarehousesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseRepository _warehouseRepository;

        #endregion

        #region Constructor

        public GetWarehousesQueryHandler(
            IMapper mapper,
            IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetWarehousesQueryResult>> Handle(
            GetWarehousesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all warehouses
                var warehouses = await _warehouseRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetWarehousesQueryResult>>(warehouses);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve warehouses: {ex.Message}");
            }
        }

        #endregion
    }
}
