using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Commands.ToggleVendorStatusCommand
{
    public class ToggleVendorStatusCommandValidator : AbstractValidator<ToggleVendorStatusCommand>
    {
        #region Constructor

        public ToggleVendorStatusCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.IsActive)
                .NotEmpty().WithMessage("Status is required.")
                .NotNull().WithMessage("Status cannot be null.");
        }

        #endregion
    }
}
