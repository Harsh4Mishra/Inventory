using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Queries.GetWarehouseByNameQuery
{
    public class GetWarehouseByNameQueryHandler : IRequestHandler<GetWarehouseByNameQuery, GetWarehouseByNameQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseRepository _warehouseRepository;

        #endregion

        #region Constructor

        public GetWarehouseByNameQueryHandler(
            IMapper mapper,
            IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetWarehouseByNameQueryResult?> Handle(
            GetWarehouseByNameQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load warehouse by name
                var warehouse = await _warehouseRepository.GetByNameAsync(request.Name, cancellationToken);

                //2. Project to the query result and return (returns null if not found)
                return _mapper.Map<GetWarehouseByNameQueryResult?>(warehouse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve warehouse: {ex.Message}");
            }
        }

        #endregion
    }
}
