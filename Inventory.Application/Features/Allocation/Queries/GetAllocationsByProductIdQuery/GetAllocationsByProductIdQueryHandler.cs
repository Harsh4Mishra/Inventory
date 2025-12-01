using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByProductIdQuery
{
    public class GetAllocationsByProductIdQueryHandler : IRequestHandler<GetAllocationsByProductIdQuery, IEnumerable<GetAllocationsByProductIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAllocationRepository _allocationRepository;

        #endregion

        #region Constructor

        public GetAllocationsByProductIdQueryHandler(
            IMapper mapper,
            IAllocationRepository allocationRepository)
        {
            _mapper = mapper;
            _allocationRepository = allocationRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetAllocationsByProductIdQueryResult>> Handle(
            GetAllocationsByProductIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load allocations by product ID
                var allocations = await _allocationRepository.GetByProductIdAsync(
                    request.ProductId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAllocationsByProductIdQueryResult>>(allocations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve allocations for product: {ex.Message}");
            }
        }

        #endregion
    }
}
