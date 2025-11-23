using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.UpdateMaterialStorageRuleCommand
{
    public class UpdateMaterialStorageRuleCommandValidator : AbstractValidator<UpdateMaterialStorageRuleCommand>
    {
        #region Ctor

        public UpdateMaterialStorageRuleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID cannot be null.");

            RuleFor(x => x.MinQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum quantity cannot be negative.");

            RuleFor(x => x.ThresholdQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Threshold quantity cannot be negative.");

            RuleFor(x => x.PreferredSectionId)
                .NotEmpty().WithMessage("Preferred section ID is required.")
                .NotNull().WithMessage("Preferred section ID cannot be null.");

            RuleFor(x => x)
                .Must(x => x.ThresholdQuantity >= x.MinQuantity)
                .WithMessage("Threshold quantity cannot be less than minimum quantity.");
        }

        #endregion
    }
}
