using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetActiveMaterialBatchesQuery
{
    public class GetActiveMaterialBatchesQueryHandler : IRequestHandler<GetActiveMaterialBatchesQuery, IEnumerable<GetActiveMaterialBatchesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialBatchRepository _materialBatchRepository;

        #endregion

        #region Constructor

        public GetActiveMaterialBatchesQueryHandler(
            IMapper mapper,
            IMaterialBatchRepository materialBatchRepository)
        {
            _mapper = mapper;
            _materialBatchRepository = materialBatchRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveMaterialBatchesQueryResult>> Handle(
            GetActiveMaterialBatchesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all material batches that are currently active
                var materialBatches = await _materialBatchRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveMaterialBatchesQueryResult>>(materialBatches);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active material batches: {ex.Message}");
            }
        }

        #endregion
    }
}
