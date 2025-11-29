using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        #region Ctor

        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID cannot be empty.")
                .NotNull().WithMessage("ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Sku)
                .NotEmpty().WithMessage("SKU cannot be empty.")
                .NotNull().WithMessage("SKU is required.")
                .MinimumLength(2).WithMessage("SKU must be at least 2 characters.")
                .MaximumLength(50).WithMessage("SKU cannot exceed 50 characters.");

            RuleFor(x => x.BomId)
                .NotEmpty().WithMessage("BOM ID cannot be empty.")
                .NotNull().WithMessage("BOM ID is required.");
        }

        #endregion
    }
}
