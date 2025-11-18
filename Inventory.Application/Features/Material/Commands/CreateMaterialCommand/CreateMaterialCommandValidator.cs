using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.CreateMaterialCommand
{
    public class CreateMaterialCommandValidator
        : AbstractValidator<CreateMaterialCommand>
    {
        #region Fields

        private readonly IMaterialRepository _materialRepository;

        #endregion

        #region Ctor

        public CreateMaterialCommandValidator(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;

            //Rule Writing
            RuleFor(x => x.Sku)
                .NotEmpty().WithMessage("SKU cannot be empty.")
                .NotNull().WithMessage("SKU is required.")
                .MinimumLength(2).WithMessage("SKU must be at least 2 characters.")
                .MaximumLength(50).WithMessage("SKU cannot exceed 50 characters.")
                .Must(ValidateIfMaterialSkuDoesNotExist).WithMessage("Material SKU already exists");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Category)
                .MaximumLength(50).WithMessage("Category cannot exceed 50 characters.");

            RuleFor(x => x.Subcategory)
                .MaximumLength(50).WithMessage("Subcategory cannot exceed 50 characters.");

            RuleFor(x => x.CasNumber)
                .MaximumLength(20).WithMessage("CAS Number cannot exceed 20 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }

        #endregion

        #region Methods

        private bool ValidateIfMaterialSkuDoesNotExist(string? sku)
        {
            var results = _materialRepository.ExistsBySkuAsync(sku);
            return results == null ? true : false;
        }

        #endregion
    }
}
