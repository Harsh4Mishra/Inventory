using FluentValidation;

namespace Inventory.Application.Features.EnumType.Commands.UpdateEnumTypeCommand
{
    public class UpdateEnumTypeCommandValidator : AbstractValidator<UpdateEnumTypeCommand>
    {
        #region Ctor

        public UpdateEnumTypeCommandValidator()
        {
            // ID validation
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Enum type ID cannot be empty.")
                .NotNull().WithMessage("Enum type ID is required.");

            // Name validation
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Matches("^[a-zA-Z0-9_ ]+$").WithMessage("Name can only contain letters, numbers, spaces, and underscores.");

            // Description validation
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }

        #endregion
    }
}
