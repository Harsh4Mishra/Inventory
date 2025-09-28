using FluentValidation;

namespace Inventory.Application.Features.Organization.Commands.DeleteOrganizationCommand
{
    public class DeleteOrganizationCommandValidator : AbstractValidator<DeleteOrganizationCommand>
    {
        #region Ctor

        public DeleteOrganizationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Organization ID cannot be empty.")
                .NotNull().WithMessage("Organization ID is required.");
        }

        #endregion
    }
}
