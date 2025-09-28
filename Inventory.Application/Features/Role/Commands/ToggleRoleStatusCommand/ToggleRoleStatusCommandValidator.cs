using FluentValidation;

namespace Inventory.Application.Features.Role.Commands.ToggleRoleStatusCommand
{
    public class ToggleRoleStatusCommandValidator : AbstractValidator<ToggleRoleStatusCommand>
    {
        #region Constructor

        public ToggleRoleStatusCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.IsActive)
                .NotEmpty().WithMessage("Status is required.")
                .NotNull().WithMessage("Status cannot be null.");
        }

        #endregion
    }
}
