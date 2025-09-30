using FluentValidation;

namespace Inventory.Application.Features.RolePermission.Commands.DeleteRolePermissionCommand
{
    public class DeleteRolePermissionCommandValidator : AbstractValidator<DeleteRolePermissionCommand>
    {
        #region Ctor

        public DeleteRolePermissionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Role-permission assignment ID is required.");
        }

        #endregion
    }
}
