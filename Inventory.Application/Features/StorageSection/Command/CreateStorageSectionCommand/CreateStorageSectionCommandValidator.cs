using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.CreateStorageSectionCommand
{
    public class CreateStorageSectionCommandValidator
        : AbstractValidator<CreateStorageSectionCommand>
    {
        #region Fields

        private readonly IStorageSectionRepository _storageSectionRepository;

        #endregion

        #region Ctor

        public CreateStorageSectionCommandValidator(IStorageSectionRepository storageSectionRepository)
        {
            _storageSectionRepository = storageSectionRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .MustAsync(ValidateIfStorageSectionDoesNotExist).WithMessage("Storage section already exists");

            RuleFor(x => x.TemperatureRange)
                .MaximumLength(50).WithMessage("Temperature range cannot exceed 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.TemperatureRange));

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfStorageSectionDoesNotExist(string? name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            var exists = await _storageSectionRepository.ExistsByNameAsync(name, cancellationToken);
            return !exists;
        }

        #endregion
    }
}
