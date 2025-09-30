using FluentValidation;

namespace Inventory.Application.Features.RolePermission.Commands.ToggleRolePermissionCommand
{
    public class ToggleRolePermissionCommandValidator : AbstractValidator<ToggleRolePermissionCommand>
    {
        #region Ctor

        public ToggleRolePermissionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Role-permission assignment ID is required.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive status is required.");
        }

        #endregion
    }
}
