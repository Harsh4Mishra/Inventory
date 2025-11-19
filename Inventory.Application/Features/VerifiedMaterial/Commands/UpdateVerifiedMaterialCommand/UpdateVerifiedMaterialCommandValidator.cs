using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.UpdateVerifiedMaterialCommand
{
    public class UpdateVerifiedMaterialCommandValidator : AbstractValidator<UpdateVerifiedMaterialCommand>
    {
        #region Ctor

        public UpdateVerifiedMaterialCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID cannot be empty.")
                .NotNull().WithMessage("ID is required.");

            RuleFor(x => x.Reason)
                .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Reason));

            // Business rule: If IsQualified is false, Reason must be provided
            RuleFor(x => x.Reason)
                .NotEmpty().WithMessage("Reason is required when material is not qualified.")
                .When(x => x.IsQualified == false);
        }

        #endregion
    }
}
