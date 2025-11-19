using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesQuery
{
    public class GetMaterialBatchesQueryHandler : IRequestHandler<GetMaterialBatchesQuery, IEnumerable<GetMaterialBatchesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialBatchRepository _materialBatchRepository;

        #endregion

        #region Constructor

        public GetMaterialBatchesQueryHandler(
            IMapper mapper,
            IMaterialBatchRepository materialBatchRepository)
        {
            _mapper = mapper;
            _materialBatchRepository = materialBatchRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetMaterialBatchesQueryResult>> Handle(
            GetMaterialBatchesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all material batches
                var materialBatches = await _materialBatchRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetMaterialBatchesQueryResult>>(materialBatches);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve material batches: {ex.Message}");
            }
        }

        #endregion
    }
}
