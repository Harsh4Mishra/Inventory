using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.UpdateAllocationQuantityCommand
{
    public class UpdateAllocationQuantityCommandValidator : AbstractValidator<UpdateAllocationQuantityCommand>
    {
        #region Ctor

        public UpdateAllocationQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID cannot be empty.")
                .NotNull().WithMessage("ID is required.")
                .NotEqual(0).WithMessage("ID cannot be empty int.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity cannot be empty.")
                .NotNull().WithMessage("Quantity is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }

        #endregion
    }
}
