using FluentValidation;

namespace Inventory.Application.Features.Role.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Ctor

        public DeleteRoleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
