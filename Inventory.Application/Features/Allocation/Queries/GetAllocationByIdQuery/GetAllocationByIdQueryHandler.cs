using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationByIdQuery
{
    public class GetAllocationByIdQueryHandler : IRequestHandler<GetAllocationByIdQuery, GetAllocationByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAllocationRepository _allocationRepository;

        #endregion

        #region Constructor

        public GetAllocationByIdQueryHandler(
            IMapper mapper,
            IAllocationRepository allocationRepository)
        {
            _mapper = mapper;
            _allocationRepository = allocationRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetAllocationByIdQueryResult?> Handle(
            GetAllocationByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load allocation by ID
                var allocation = await _allocationRepository.GetByIdAsync(
                    request.Id, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<GetAllocationByIdQueryResult?>(allocation);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve allocation: {ex.Message}");
            }
        }

        #endregion
    }
}
