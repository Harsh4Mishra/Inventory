using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Commands.UpdateBomItemQuantityCommand
{
    public class UpdateBomItemQuantityCommandValidator : AbstractValidator<UpdateBomItemQuantityCommand>
    {
        #region Ctor

        public UpdateBomItemQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID cannot be null.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .NotEmpty().WithMessage("Quantity is required.");
        }

        #endregion
    }
}
