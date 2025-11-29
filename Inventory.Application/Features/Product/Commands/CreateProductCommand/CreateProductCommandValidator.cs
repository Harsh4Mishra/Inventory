using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommandValidator
        : AbstractValidator<CreateProductCommand>
    {
        #region Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Ctor

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .MustAsync(ValidateIfProductNameDoesNotExist).WithMessage("Product name already exists");

            RuleFor(x => x.Sku)
                .NotEmpty().WithMessage("SKU cannot be empty.")
                .NotNull().WithMessage("SKU is required.")
                .MinimumLength(2).WithMessage("SKU must be at least 2 characters.")
                .MaximumLength(50).WithMessage("SKU cannot exceed 50 characters.")
                .MustAsync(ValidateIfProductSkuDoesNotExist).WithMessage("Product SKU already exists");

            RuleFor(x => x.BomId)
                .NotEmpty().WithMessage("BOM ID cannot be empty.")
                .NotNull().WithMessage("BOM ID is required.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfProductNameDoesNotExist(string? productName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return true;

            return !await _productRepository.ExistsByNameAsync(productName, cancellationToken);
        }

        private async Task<bool> ValidateIfProductSkuDoesNotExist(string? sku, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(sku))
                return true;

            return !await _productRepository.ExistsBySkuAsync(sku, cancellationToken);
        }

        #endregion
    }
}
