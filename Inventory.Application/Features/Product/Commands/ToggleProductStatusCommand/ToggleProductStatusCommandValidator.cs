using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.ToggleProductStatusCommand
{
    public class ToggleProductStatusCommandValidator : AbstractValidator<ToggleProductStatusCommand>
    {
        #region Constructor

        public ToggleProductStatusCommandValidator()
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
