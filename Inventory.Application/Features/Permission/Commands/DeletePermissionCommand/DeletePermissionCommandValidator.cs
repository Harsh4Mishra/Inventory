using FluentValidation;

namespace Inventory.Application.Features.Permission.Commands.DeletePermissionCommand
{
    public class DeletePermissionCommandValidator : AbstractValidator<DeletePermissionCommand>
    {
        #region Ctor

        public DeletePermissionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Permission ID is required.");
        }

        #endregion
    }
}
