using FluentValidation;

namespace Inventory.Application.Features.EnumType.Commands.ToggleEnumTypeStatusCommand
{
    public class ToggleEnumTypeStatusCommandValidator
        : AbstractValidator<ToggleEnumTypeStatusCommand>
    {
        #region Ctor

        public ToggleEnumTypeStatusCommandValidator()
        {
            // ID validation
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Enum type ID cannot be empty.")
                .NotNull().WithMessage("Enum type ID is required.");

            // IsActive validation
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive status is required.");
        }

        #endregion
    }
}
