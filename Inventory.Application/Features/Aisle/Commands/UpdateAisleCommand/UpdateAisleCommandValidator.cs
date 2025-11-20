using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Commands.UpdateAisleCommand
{
    public class UpdateAisleCommandValidator : AbstractValidator<UpdateAisleCommand>
    {
        #region Ctor

        public UpdateAisleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Aisle Id cannot be empty.")
                .NotNull().WithMessage("Aisle Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.StorageSectionId)
                .NotEmpty().WithMessage("Storage Section Id is required.")
                .NotNull().WithMessage("Storage Section Id cannot be empty.");

            RuleFor(x => x.StorageTypeId)
                .NotEmpty().WithMessage("Storage Type Id is required.")
                .NotNull().WithMessage("Storage Type Id cannot be empty.");

            RuleFor(x => x.InventoryTypeId)
                .NotEmpty().WithMessage("Inventory Type Id is required.")
                .NotNull().WithMessage("Inventory Type Id cannot be empty.");
        }

        #endregion
    }
}
