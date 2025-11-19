using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.ToggleAllotmentCommand
{
    public class ToggleAllotmentCommandValidator : AbstractValidator<ToggleAllotmentCommand>
    {
        #region Constructor

        public ToggleAllotmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.IsAllotted)
                .NotEmpty().WithMessage("Allotment status is required.")
                .NotNull().WithMessage("Allotment status cannot be null.");
        }

        #endregion
    }
}
