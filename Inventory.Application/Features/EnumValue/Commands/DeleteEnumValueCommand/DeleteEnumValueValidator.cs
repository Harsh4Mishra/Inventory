using FluentValidation;

namespace Inventory.Application.Features.EnumValue.Commands.DeleteEnumValueCommand
{
    public class DeleteEnumValueValidator : AbstractValidator<DeleteEnumValueCommand>
    {
        #region Ctor

        public DeleteEnumValueValidator()
        {
            // EnumTypeId validation
            RuleFor(x => x.EnumTypeId)
                .NotEmpty().WithMessage("Enum type ID cannot be empty.")
                .NotNull().WithMessage("Enum type ID is required.");

            // EnumValue Id validation
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Enum value ID cannot be empty.")
                .NotNull().WithMessage("Enum value ID is required.");
        }

        #endregion
    }
}
