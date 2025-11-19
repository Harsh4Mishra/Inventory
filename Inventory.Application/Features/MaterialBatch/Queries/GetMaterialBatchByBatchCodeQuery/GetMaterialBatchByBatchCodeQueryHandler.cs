using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchByBatchCodeQuery
{
    public class GetMaterialBatchByBatchCodeQueryHandler : IRequestHandler<GetMaterialBatchByBatchCodeQuery, GetMaterialBatchByBatchCodeQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialBatchRepository _materialBatchRepository;

        #endregion

        #region Constructor

        public GetMaterialBatchByBatchCodeQueryHandler(
            IMapper mapper,
            IMaterialBatchRepository materialBatchRepository)
        {
            _mapper = mapper;
            _materialBatchRepository = materialBatchRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetMaterialBatchByBatchCodeQueryResult> Handle(
            GetMaterialBatchByBatchCodeQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load material batch by batch code
                var materialBatch = await _materialBatchRepository.GetByBatchCodeAsync(request.BatchCode, cancellationToken);

                //2. If not found, throw exception
                if (materialBatch == null)
                {
                    throw new InvalidOperationException($"No material batch found with batch code '{request.BatchCode}'.");
                }

                //3. Project to the query result and return
                return _mapper.Map<GetMaterialBatchByBatchCodeQueryResult>(materialBatch);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve material batch: {ex.Message}");
            }
        }

        #endregion
    }
}
