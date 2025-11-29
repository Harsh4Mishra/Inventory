using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetProductByIdQuery
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public GetProductByIdQueryHandler(
            IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetProductByIdQueryResult> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load product by ID
                var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. Return null if not found, or map to result
                return product == null
                    ? throw new InvalidOperationException($"No product found with ID '{request.Id}'.")
                    : _mapper.Map<GetProductByIdQueryResult>(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve product by ID: {ex.Message}");
            }
        }

        #endregion
    }
}
