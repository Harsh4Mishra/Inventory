using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.RemoveWarehouseItemQuantityCommand
{
    public class RemoveWarehouseItemQuantityCommandValidator : AbstractValidator<RemoveWarehouseItemQuantityCommand>
    {
        #region Ctor

        public RemoveWarehouseItemQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID cannot be null.");

            RuleFor(x => x.QuantityToRemove)
                .GreaterThan(0).WithMessage("Quantity to remove must be greater than zero.")
                .NotEmpty().WithMessage("Quantity to remove is required.");
        }

        #endregion
    }
}
