using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsQuery
{
    public class GetAllocationsQueryHandler : IRequestHandler<GetAllocationsQuery, IEnumerable<GetAllocationsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAllocationRepository _allocationRepository;

        #endregion

        #region Constructor

        public GetAllocationsQueryHandler(
            IMapper mapper,
            IAllocationRepository allocationRepository)
        {
            _mapper = mapper;
            _allocationRepository = allocationRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetAllocationsQueryResult>> Handle(
            GetAllocationsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all allocations
                var allocations = await _allocationRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAllocationsQueryResult>>(allocations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve allocations: {ex.Message}");
            }
        }

        #endregion
    }
}
