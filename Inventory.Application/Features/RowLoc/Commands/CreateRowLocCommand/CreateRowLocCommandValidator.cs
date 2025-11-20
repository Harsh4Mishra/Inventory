using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Commands.CreateRowLocCommand
{
    public class CreateRowLocCommandValidator
        : AbstractValidator<CreateRowLocCommand>
    {
        #region Ctor

        public CreateRowLocCommandValidator()
        {
            RuleFor(x => x.AisleId)
                .NotEmpty().WithMessage("Aisle Id cannot be empty.")
                .NotNull().WithMessage("Aisle Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
        }

        #endregion
    }
}
