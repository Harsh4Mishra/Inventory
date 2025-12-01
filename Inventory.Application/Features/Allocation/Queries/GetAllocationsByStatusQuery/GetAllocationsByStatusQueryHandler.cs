using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByStatusQuery
{
    public class GetAllocationsByStatusQueryHandler : IRequestHandler<GetAllocationsByStatusQuery, IEnumerable<GetAllocationsByStatusQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAllocationRepository _allocationRepository;

        #endregion

        #region Constructor

        public GetAllocationsByStatusQueryHandler(
            IMapper mapper,
            IAllocationRepository allocationRepository)
        {
            _mapper = mapper;
            _allocationRepository = allocationRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetAllocationsByStatusQueryResult>> Handle(
            GetAllocationsByStatusQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate status
                var validStatuses = new[] { "allocated", "picked", "shipped", "released", "cancelled" };
                if (!validStatuses.Contains(request.Status.ToLower()))
                {
                    throw new InvalidOperationException($"Invalid status: {request.Status}. Valid statuses are: {string.Join(", ", validStatuses)}");
                }

                // 2. Load allocations by status
                var allocations = await _allocationRepository.GetByStatusAsync(
                    request.Status, cancellationToken);

                // 3. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAllocationsByStatusQueryResult>>(allocations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve allocations by status: {ex.Message}");
            }
        }

        #endregion
    }
}
