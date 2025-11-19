using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchByIdQuery
{
    public class GetMaterialBatchByIdQueryHandler : IRequestHandler<GetMaterialBatchByIdQuery, GetMaterialBatchByIdQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialBatchRepository _materialBatchRepository;

        #endregion

        #region Constructor

        public GetMaterialBatchByIdQueryHandler(
            IMapper mapper,
            IMaterialBatchRepository materialBatchRepository)
        {
            _mapper = mapper;
            _materialBatchRepository = materialBatchRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetMaterialBatchByIdQueryResult> Handle(
            GetMaterialBatchByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load material batch by ID
                var materialBatch = await _materialBatchRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. If not found, throw exception
                if (materialBatch == null)
                {
                    throw new InvalidOperationException($"No material batch found with Id '{request.Id}'.");
                }

                //3. Project to the query result and return
                return _mapper.Map<GetMaterialBatchByIdQueryResult>(materialBatch);
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
