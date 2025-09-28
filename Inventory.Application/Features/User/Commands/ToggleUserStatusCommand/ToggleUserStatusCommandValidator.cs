using FluentValidation;

namespace Inventory.Application.Features.User.Commands.ToggleUserStatusCommand
{
    public class ToggleUserStatusCommandValidator
        : AbstractValidator<ToggleUserStatusCommand>
    {
        #region Fields


        #endregion

        #region Ctor

        public ToggleUserStatusCommandValidator()
        {
            //Rule Writing
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User Id cannot be empty.")
                .NotNull().WithMessage("User Id is required.");

            RuleFor(x => x.IsActive).NotEmpty().NotNull();

        }

        #endregion

        #region Methods

        #endregion
    }
}
