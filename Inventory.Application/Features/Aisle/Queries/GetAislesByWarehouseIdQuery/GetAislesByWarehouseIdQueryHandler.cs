using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Queries.GetAislesByWarehouseIdQuery
{
    public class GetAislesByWarehouseIdQueryHandler
        : IRequestHandler<GetAislesByWarehouseIdQuery, IEnumerable<GetAislesByWarehouseIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAisleRepository _aisleRepository;

        #endregion

        #region Ctor

        public GetAislesByWarehouseIdQueryHandler(
            IMapper mapper,
            IAisleRepository aisleRepository)
        {
            _mapper = mapper;
            _aisleRepository = aisleRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetAislesByWarehouseIdQueryResult>> Handle(
            GetAislesByWarehouseIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load aisles by warehouse id
                var result = await _aisleRepository.GetByWarehouseIdAsync(request.WarehouseId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAislesByWarehouseIdQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve aisles by warehouse id " + ex.Message);
            }
        }

        #endregion
    }
}
