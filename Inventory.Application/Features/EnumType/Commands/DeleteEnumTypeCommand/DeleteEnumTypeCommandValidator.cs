using FluentValidation;

namespace Inventory.Application.Features.EnumType.Commands.DeleteEnumTypeCommand
{
    public class DeleteEnumTypeCommandValidator : AbstractValidator<DeleteEnumTypeCommand>
    {
        #region Ctor

        public DeleteEnumTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Enum type ID is required.")
                .NotNull().WithMessage("Enum type ID cannot be null.");
        }

        #endregion
    }
}
