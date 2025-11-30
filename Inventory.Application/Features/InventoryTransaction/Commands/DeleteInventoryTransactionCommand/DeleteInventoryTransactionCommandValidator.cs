using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.DeleteInventoryTransactionCommand
{
    public class DeleteInventoryTransactionCommandValidator : AbstractValidator<DeleteInventoryTransactionCommand>
    {
        #region Ctor

        public DeleteInventoryTransactionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .NotNull().WithMessage("Id is required.");
        }

        #endregion
    }
}
