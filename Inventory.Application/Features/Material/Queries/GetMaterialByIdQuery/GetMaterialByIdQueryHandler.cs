using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Queries.GetMaterialByIdQuery
{
    public class GetMaterialByIdQueryHandler : IRequestHandler<GetMaterialByIdQuery, GetMaterialByIdQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;

        #endregion

        #region Constructor

        public GetMaterialByIdQueryHandler(
            IMapper mapper,
            IMaterialRepository materialRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetMaterialByIdQueryResult> Handle(
            GetMaterialByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load material by ID
                var material = await _materialRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. If not found, throw exception
                if (material == null)
                {
                    throw new InvalidOperationException($"No material found with Id '{request.Id}'.");
                }

                //3. Project to the query result and return
                return _mapper.Map<GetMaterialByIdQueryResult>(material);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve material: {ex.Message}");
            }
        }

        #endregion
    }
}
