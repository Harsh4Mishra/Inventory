using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Queries.GetActiveWarehousesQuery
{
    public class GetActiveWarehousesQueryHandler : IRequestHandler<GetActiveWarehousesQuery, IEnumerable<GetActiveWarehousesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseRepository _warehouseRepository;

        #endregion

        #region Constructor

        public GetActiveWarehousesQueryHandler(
            IMapper mapper,
            IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveWarehousesQueryResult>> Handle(
            GetActiveWarehousesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all warehouses that are currently active
                var warehouses = await _warehouseRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveWarehousesQueryResult>>(warehouses);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active warehouses: {ex.Message}");
            }
        }

        #endregion
    }
}
