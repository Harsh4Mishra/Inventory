using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetProductBySkuQuery
{
    public class GetProductBySkuQueryHandler : IRequestHandler<GetProductBySkuQuery, GetProductBySkuQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public GetProductBySkuQueryHandler(
            IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetProductBySkuQueryResult> Handle(
            GetProductBySkuQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load product by SKU
                var product = await _productRepository.GetBySkuAsync(request.Sku, cancellationToken);

                //2. Return null if not found, or map to result
                return product == null
                    ? throw new InvalidOperationException($"No product found with SKU '{request.Sku}'.")
                    : _mapper.Map<GetProductBySkuQueryResult>(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve product by SKU: {ex.Message}");
            }
        }

        #endregion
    }
}
