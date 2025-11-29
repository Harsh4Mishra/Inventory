using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetProductsQuery
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<GetProductsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public GetProductsQueryHandler(
            IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetProductsQueryResult>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all products
                var products = await _productRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetProductsQueryResult>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve products: {ex.Message}");
            }
        }

        #endregion
    }
}
