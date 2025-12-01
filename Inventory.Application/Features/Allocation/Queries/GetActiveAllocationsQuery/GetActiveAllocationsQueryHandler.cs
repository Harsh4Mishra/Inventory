using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetActiveAllocationsQuery
{
    public class GetActiveAllocationsQueryHandler : IRequestHandler<GetActiveAllocationsQuery, IEnumerable<GetActiveAllocationsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAllocationRepository _allocationRepository;

        #endregion

        #region Constructor

        public GetActiveAllocationsQueryHandler(
            IMapper mapper,
            IAllocationRepository allocationRepository)
        {
            _mapper = mapper;
            _allocationRepository = allocationRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveAllocationsQueryResult>> Handle(
            GetActiveAllocationsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load active allocations (allocated or picked)
                var allocations = await _allocationRepository.GetActiveAllocationsAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveAllocationsQueryResult>>(allocations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active allocations: {ex.Message}");
            }
        }

        #endregion
    }
}
