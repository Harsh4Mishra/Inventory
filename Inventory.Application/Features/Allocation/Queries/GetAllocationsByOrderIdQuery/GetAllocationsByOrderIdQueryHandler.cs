using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByOrderIdQuery
{
    public class GetAllocationsByOrderIdQueryHandler : IRequestHandler<GetAllocationsByOrderIdQuery, IEnumerable<GetAllocationsByOrderIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAllocationRepository _allocationRepository;

        #endregion

        #region Constructor

        public GetAllocationsByOrderIdQueryHandler(
            IMapper mapper,
            IAllocationRepository allocationRepository)
        {
            _mapper = mapper;
            _allocationRepository = allocationRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetAllocationsByOrderIdQueryResult>> Handle(
            GetAllocationsByOrderIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load allocations by order ID
                var allocations = await _allocationRepository.GetByOrderIdAsync(
                    request.OrderId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAllocationsByOrderIdQueryResult>>(allocations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve allocations for order: {ex.Message}");
            }
        }

        #endregion
    }
}
