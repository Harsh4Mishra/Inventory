using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.DeleteAllocationCommand
{
    public class DeleteAllocationCommandValidator : AbstractValidator<DeleteAllocationCommand>
    {
        #region Ctor

        public DeleteAllocationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID cannot be empty.")
                .NotNull().WithMessage("ID is required.")
                .NotEqual(0).WithMessage("ID cannot be empty int.");
        }

        #endregion
    }
}
