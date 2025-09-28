using FluentValidation;

namespace Inventory.Application.Features.EnumValue.Commands.UpdateEnumValueCommand
{
    public class UpdateEnumValueValidator : AbstractValidator<UpdateEnumValueCommand>
    {
        #region Ctor

        public UpdateEnumValueValidator()
        {
            // ID validation
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Enum value ID cannot be empty.")
                .NotNull().WithMessage("Enum value ID is required.");

            // EnumTypeId validation
            RuleFor(x => x.EnumTypeId)
                .NotEmpty().WithMessage("Enum type ID cannot be empty.")
                .NotNull().WithMessage("Enum type ID is required.");

            // Name validation
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Matches("^[a-zA-Z0-9_ ]+$").WithMessage("Name can only contain letters, numbers, spaces, and underscores.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description is required.")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");
        }

        #endregion
    }
}
