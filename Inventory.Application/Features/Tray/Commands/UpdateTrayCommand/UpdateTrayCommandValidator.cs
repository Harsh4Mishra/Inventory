using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Commands.UpdateTrayCommand
{
    public class UpdateTrayCommandValidator : AbstractValidator<UpdateTrayCommand>
    {
        #region Ctor

        public UpdateTrayCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Tray Id cannot be empty.")
                .NotNull().WithMessage("Tray Id is required.");

            RuleFor(x => x.AisleId)
                .NotEmpty().WithMessage("Aisle Id cannot be empty.")
                .NotNull().WithMessage("Aisle Id is required.");

            RuleFor(x => x.RowLocId)
                .NotEmpty().WithMessage("Row Location Id cannot be empty.")
                .NotNull().WithMessage("Row Location Id is required.");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Capacity must be greater than 0.");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
        }

        #endregion
    }
}
