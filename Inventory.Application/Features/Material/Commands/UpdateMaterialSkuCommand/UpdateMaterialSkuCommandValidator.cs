using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.UpdateMaterialSkuCommand
{
    public class UpdateMaterialSkuCommandValidator : AbstractValidator<UpdateMaterialSkuCommand>
    {
        #region Fields

        private readonly IMaterialRepository _materialRepository;

        #endregion

        #region Ctor

        public UpdateMaterialSkuCommandValidator(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.Sku)
                .NotEmpty().WithMessage("SKU cannot be empty.")
                .NotNull().WithMessage("SKU is required.")
                .MinimumLength(2).WithMessage("SKU must be at least 2 characters.")
                .MaximumLength(50).WithMessage("SKU cannot exceed 50 characters.")
                .Must(ValidateIfMaterialSkuDoesNotExist).WithMessage("Material SKU already exists");
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
