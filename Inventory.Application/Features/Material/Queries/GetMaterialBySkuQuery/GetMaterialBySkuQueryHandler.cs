using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Queries.GetMaterialBySkuQuery
{
    public class GetMaterialBySkuQueryHandler : IRequestHandler<GetMaterialBySkuQuery, GetMaterialBySkuQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;

        #endregion

        #region Constructor

        public GetMaterialBySkuQueryHandler(
            IMapper mapper,
            IMaterialRepository materialRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetMaterialBySkuQueryResult> Handle(
            GetMaterialBySkuQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load material by SKU
                var material = await _materialRepository.GetBySkuAsync(request.Sku, cancellationToken);

                //2. If not found, throw exception
                if (material == null)
                {
                    throw new InvalidOperationException($"No material found with SKU '{request.Sku}'.");
                }

                //3. Project to the query result and return
                return _mapper.Map<GetMaterialBySkuQueryResult>(material);
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
