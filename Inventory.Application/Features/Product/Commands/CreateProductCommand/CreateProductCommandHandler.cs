using AutoMapper;
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public CreateProductCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates by SKU
                if (await _productRepository.ExistsBySkuAsync(request.Sku, cancellationToken))
                {
                    throw new InvalidOperationException($"A product with SKU '{request.Sku}' already exists.");
                }

                // 2. Prevent duplicates by Name
                if (await _productRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"A product named '{request.Name}' already exists.");
                }

                // 3. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Create and persist the new product
                var product = ProductDO.Create(
                    request.Name,
                    request.Sku,
                    request.BomId,
                    userName);

                _productRepository.Add(product);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return product.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create product: {ex.Message}");
            }
        }

        #endregion
    }
}
