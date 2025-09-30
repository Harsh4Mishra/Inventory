using FluentValidation;

namespace Inventory.Application.Features.UserRole.Commands.DeleteUserRoleCommand
{
    public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
    {
        #region Ctor

        public DeleteUserRoleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("User-role assignment ID is required.");
        }

        #endregion
    }
}
