using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.UpdateAllocationStatusCommand
{
    public class UpdateAllocationStatusCommandValidator : AbstractValidator<UpdateAllocationStatusCommand>
    {
        #region Ctor

        public UpdateAllocationStatusCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID cannot be empty.")
                .NotNull().WithMessage("ID is required.")
                .NotEqual(0).WithMessage("ID cannot be empty int.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status cannot be empty.")
                .NotNull().WithMessage("Status is required.")
                .Must(BeValidStatus).WithMessage("Status must be one of: picked, shipped, released, cancelled");
        }

        #endregion

        #region Methods

        private bool BeValidStatus(string status)
        {
            var validStatuses = new[] { "picked", "shipped", "released", "cancelled" };
            return validStatuses.Contains(status?.ToLower());
        }

        #endregion
    }
}
