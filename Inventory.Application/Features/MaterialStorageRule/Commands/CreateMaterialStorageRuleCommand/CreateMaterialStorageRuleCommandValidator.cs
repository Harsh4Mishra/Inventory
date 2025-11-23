using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.CreateMaterialStorageRuleCommand
{
    public class CreateMaterialStorageRuleCommandValidator : AbstractValidator<CreateMaterialStorageRuleCommand>
    {
        #region Fields

        private readonly IMaterialStorageRuleRepository _materialStorageRuleRepository;

        #endregion

        #region Ctor

        public CreateMaterialStorageRuleCommandValidator(IMaterialStorageRuleRepository materialStorageRuleRepository)
        {
            _materialStorageRuleRepository = materialStorageRuleRepository;

            RuleFor(x => x.MaterialId)
                .NotEmpty().WithMessage("Material ID is required.")
                .NotNull().WithMessage("Material ID cannot be null.");

            RuleFor(x => x.MinQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum quantity cannot be negative.");

            RuleFor(x => x.ThresholdQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Threshold quantity cannot be negative.");

            RuleFor(x => x.PreferredSectionId)
                .NotEmpty().WithMessage("Preferred section ID is required.")
                .NotNull().WithMessage("Preferred section ID cannot be null.");

            RuleFor(x => x)
                .Must(x => x.ThresholdQuantity >= x.MinQuantity)
                .WithMessage("Threshold quantity cannot be less than minimum quantity.")
                .MustAsync(ValidateIfMaterialRuleDoesNotExist)
                .WithMessage("Storage rule already exists for this material.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfMaterialRuleDoesNotExist(CreateMaterialStorageRuleCommand command, CancellationToken cancellationToken)
        {
            return !await _materialStorageRuleRepository.ExistsByMaterialIdAsync(command.MaterialId, cancellationToken);
        }

        #endregion
    }
}
