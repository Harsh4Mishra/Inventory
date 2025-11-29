using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetActiveProductsQuery
{
    public class GetActiveProductsQueryHandler : IRequestHandler<GetActiveProductsQuery, IEnumerable<GetActiveProductsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public GetActiveProductsQueryHandler(
            IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveProductsQueryResult>> Handle(
            GetActiveProductsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all products that are currently active
                var products = await _productRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveProductsQueryResult>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active products: {ex.Message}");
            }
        }

        #endregion
    }
}
