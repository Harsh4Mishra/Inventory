using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand, Unit>
    {
        #region Fields

        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the product or fail if it doesn't exist
                var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No product found with Id '{request.Id}'.");

                //2. Remove and persist
                _productRepository.Remove(product);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete product: {ex.Message}");
            }
        }

        #endregion
    }
}
