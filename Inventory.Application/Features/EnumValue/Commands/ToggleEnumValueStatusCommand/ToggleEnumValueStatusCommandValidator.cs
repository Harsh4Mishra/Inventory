using FluentValidation;

namespace Inventory.Application.Features.EnumValue.Commands.ToggleEnumValueStatusCommand
{
    public class ToggleEnumValueStatusCommandValidator
        : AbstractValidator<ToggleEnumValueStatusCommand>
    {
        #region Ctor

        public ToggleEnumValueStatusCommandValidator()
        {
            // ID validation
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Enum value ID cannot be empty.")
                .NotNull().WithMessage("Enum value ID is required.");

            // EnumTypeId validation
            RuleFor(x => x.EnumTypeId)
                .NotEmpty().WithMessage("Enum type ID cannot be empty.")
                .NotNull().WithMessage("Enum type ID is required.");

            // IsActive validation
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive status is required.");
        }

        #endregion
    }
}
