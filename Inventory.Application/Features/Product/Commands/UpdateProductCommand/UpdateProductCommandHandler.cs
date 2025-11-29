using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateProductCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing product or fail if it doesn't exist
                var product = await _productRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No product found with Id '{request.Id}'.");

                //2. Check if SKU is already taken by another product
                var existingProductWithSku = await _productRepository.GetBySkuAsync(request.Sku, cancellationToken);
                if (existingProductWithSku != null && existingProductWithSku.Id != request.Id)
                {
                    throw new InvalidOperationException($"Another product with SKU '{request.Sku}' already exists.");
                }

                //3. Check if name is already taken by another product
                var existingProductWithName = await _productRepository.GetByNameAsync(request.Name, cancellationToken);
                if (existingProductWithName != null && existingProductWithName.Id != request.Id)
                {
                    throw new InvalidOperationException($"Another product with name '{request.Name}' already exists.");
                }

                //4. Identify who's making the change
                var userName = "System";

                //5. Apply updates and persist the changes
                product.Update(request.Name, request.Sku, request.BomId, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update product: {ex.Message}");
            }
        }

        #endregion
    }
}
