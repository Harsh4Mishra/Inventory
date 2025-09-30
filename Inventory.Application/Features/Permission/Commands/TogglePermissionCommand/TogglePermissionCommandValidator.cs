using FluentValidation;

namespace Inventory.Application.Features.Permission.Commands.TogglePermissionCommand
{
    public class TogglePermissionCommandValidator : AbstractValidator<TogglePermissionCommand>
    {
        #region Ctor

        public TogglePermissionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Permission ID is required.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive status is required.");
        }

        #endregion
    }
}
