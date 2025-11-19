using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesByMaterialIdQuery
{
    public class GetMaterialBatchesByMaterialIdQueryHandler : IRequestHandler<GetMaterialBatchesByMaterialIdQuery, IEnumerable<GetMaterialBatchesByMaterialIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialBatchRepository _materialBatchRepository;

        #endregion

        #region Constructor

        public GetMaterialBatchesByMaterialIdQueryHandler(
            IMapper mapper,
            IMaterialBatchRepository materialBatchRepository)
        {
            _mapper = mapper;
            _materialBatchRepository = materialBatchRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetMaterialBatchesByMaterialIdQueryResult>> Handle(
            GetMaterialBatchesByMaterialIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load material batches by material ID
                var materialBatches = await _materialBatchRepository.GetByMaterialIdAsync(request.MaterialId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetMaterialBatchesByMaterialIdQueryResult>>(materialBatches);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve material batches for material ID '{request.MaterialId}': {ex.Message}");
            }
        }

        #endregion
    }
}
