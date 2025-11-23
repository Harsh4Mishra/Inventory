using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.AddWarehouseItemQuantityCommand
{
    public class AddWarehouseItemQuantityCommandValidator : AbstractValidator<AddWarehouseItemQuantityCommand>
    {
        #region Ctor

        public AddWarehouseItemQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID cannot be null.");

            RuleFor(x => x.QuantityToAdd)
                .GreaterThan(0).WithMessage("Quantity to add must be greater than zero.")
                .NotEmpty().WithMessage("Quantity to add is required.");
        }

        #endregion
    }
}
