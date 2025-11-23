using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.UpdateWarehouseItemQuantityCommand
{
    public class UpdateWarehouseItemQuantityCommandValidator : AbstractValidator<UpdateWarehouseItemQuantityCommand>
    {
        #region Ctor

        public UpdateWarehouseItemQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID cannot be null.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.")
                .NotEmpty().WithMessage("Quantity is required.");
        }

        #endregion
    }
}
