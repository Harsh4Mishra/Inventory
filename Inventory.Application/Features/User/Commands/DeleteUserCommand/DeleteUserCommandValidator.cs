
using FluentValidation;

namespace Inventory.Application.Features.User.Commands.DeleteUserCommand
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        #region Ctor

        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User Id is required.")
                .NotNull().WithMessage("User Id cannot be null.");
        }

        #endregion
    }
}
