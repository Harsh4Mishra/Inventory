using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.ToggleProductStatusCommand
{
    public class ToggleProductStatusCommandHandler : IRequestHandler<ToggleProductStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleProductStatusCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            ToggleProductStatusCommand request,
            CancellationToken cancellationToken)
        {
            //1. Load the product or fail if it doesn't exist
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new InvalidOperationException($"No product found with Id '{request.Id}'.");

            //2. Identify who's performing the toggle
            var userName = "System"; // TODO: Replace with actual user identification

            if (request.IsActive)
            {
                product.Activate(userName);
            }
            else
            {
                product.Deactivate(userName);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        #endregion
    }
}
