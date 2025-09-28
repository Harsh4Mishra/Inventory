using FluentValidation;

namespace Inventory.Application.Features.EnumValue.Commands.CreateEnumValueCommand
{
    public class CreateEnumValueValidator
        : AbstractValidator<CreateEnumValueCommand>
    {
        #region Fields


        #endregion

        #region Ctor

        public CreateEnumValueValidator()
        {

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description is required.")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");
        }

        #endregion

        #region Methods

        #endregion
    }
}
