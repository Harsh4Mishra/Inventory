using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByMaterialBatchIdQuery
{
    public class GetAllocationsByMaterialBatchIdQueryHandler : IRequestHandler<GetAllocationsByMaterialBatchIdQuery, IEnumerable<GetAllocationsByMaterialBatchIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAllocationRepository _allocationRepository;

        #endregion

        #region Constructor

        public GetAllocationsByMaterialBatchIdQueryHandler(
            IMapper mapper,
            IAllocationRepository allocationRepository)
        {
            _mapper = mapper;
            _allocationRepository = allocationRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetAllocationsByMaterialBatchIdQueryResult>> Handle(
            GetAllocationsByMaterialBatchIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load allocations by material batch ID
                var allocations = await _allocationRepository.GetByMaterialBatchIdAsync(
                    request.MaterialBatchId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAllocationsByMaterialBatchIdQueryResult>>(allocations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve allocations for material batch: {ex.Message}");
            }
        }

        #endregion
    }
}
