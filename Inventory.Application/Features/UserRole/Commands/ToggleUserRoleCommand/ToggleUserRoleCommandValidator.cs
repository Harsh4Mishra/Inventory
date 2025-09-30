using FluentValidation;

namespace Inventory.Application.Features.UserRole.Commands.ToggleUserRoleCommand
{
    public class ToggleUserRoleCommandValidator : AbstractValidator<ToggleUserRoleCommand>
    {
        #region Ctor

        public ToggleUserRoleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("User-role assignment ID is required.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive status is required.");
        }

        #endregion
    }
}
