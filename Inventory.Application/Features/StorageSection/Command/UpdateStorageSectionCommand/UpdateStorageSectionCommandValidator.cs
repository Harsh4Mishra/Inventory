using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.UpdateStorageSectionCommand
{
    public class UpdateStorageSectionCommandValidator : AbstractValidator<UpdateStorageSectionCommand>
    {
        #region Ctor

        public UpdateStorageSectionCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.TemperatureRange)
                .MaximumLength(50).WithMessage("Temperature range cannot exceed 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.TemperatureRange));

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }

        #endregion
    }
}
