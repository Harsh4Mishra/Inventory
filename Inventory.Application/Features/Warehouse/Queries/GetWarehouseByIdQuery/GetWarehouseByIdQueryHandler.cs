using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Queries.GetWarehouseByIdQuery
{
    public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, GetWarehouseByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IWarehouseRepository _warehouseRepository;

        #endregion

        #region Constructor

        public GetWarehouseByIdQueryHandler(
            IMapper mapper,
            IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetWarehouseByIdQueryResult?> Handle(
            GetWarehouseByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load warehouse by ID
                var warehouse = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. Project to the query result and return (returns null if not found)
                return _mapper.Map<GetWarehouseByIdQueryResult?>(warehouse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve warehouse: {ex.Message}");
            }
        }

        #endregion
    }
}
