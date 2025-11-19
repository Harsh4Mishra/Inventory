using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.UpdateQuantityCommand
{
    public class UpdateQuantityCommandValidator : AbstractValidator<UpdateQuantityCommand>
    {
        #region Constructor

        public UpdateQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThan(1000000).WithMessage("Quantity cannot exceed 1,000,000.");
        }

        #endregion
    }
}
