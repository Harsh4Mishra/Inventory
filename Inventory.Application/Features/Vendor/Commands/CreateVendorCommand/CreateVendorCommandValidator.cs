using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.Vendor.Commands.CreateVendorCommand
{
    public class CreateVendorCommandValidator
        : AbstractValidator<CreateVendorCommand>
    {
        #region Fields

        private readonly IVendorRepository _vendorRepository;

        #endregion

        #region Ctor

        public CreateVendorCommandValidator(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .Must(ValidateIfVendorDoesNotExist).WithMessage("Vendor already exists");

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

        #region Methods

        private bool ValidateIfVendorDoesNotExist(string? vendorName)
        {
            var results = _vendorRepository.ExistsByNameAsync(vendorName);
            return results == null ? true : false;
        }

        #endregion
    }
}
