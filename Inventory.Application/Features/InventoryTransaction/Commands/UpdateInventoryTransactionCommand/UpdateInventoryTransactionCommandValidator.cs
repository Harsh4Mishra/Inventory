using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.UpdateInventoryTransactionCommand
{
    public class UpdateInventoryTransactionCommandValidator : AbstractValidator<UpdateInventoryTransactionCommand>
    {
        #region Ctor

        public UpdateInventoryTransactionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .NotNull().WithMessage("Id is required.");

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0).When(x => x.Cost.HasValue)
                .WithMessage("Cost must be greater than or equal to 0.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");
        }

        #endregion
    }
}
