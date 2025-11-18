using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Commands.UpdateVendorCommand
{
    public class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand>
    {
        #region Ctor

        public UpdateVendorCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type cannot be empty.")
                .NotNull().WithMessage("Type is required.")
                .MaximumLength(50).WithMessage("Type cannot exceed 50 characters.");

            RuleFor(x => x.Contact)
                .NotEmpty().WithMessage("Contact cannot be empty.")
                .NotNull().WithMessage("Contact is required.")
                .MaximumLength(100).WithMessage("Contact cannot exceed 100 characters.");
        }

        #endregion
    }
}
