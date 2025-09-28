using FluentValidation;

namespace Inventory.Application.Features.Organization.Commands.ToggleOrganizationStatusCommand
{
    public class ToggleOrganizationStatusCommandValidator
        : AbstractValidator<ToggleOrganizationStatusCommand>
    {
        #region Ctor

        public ToggleOrganizationStatusCommandValidator()
        {
            // ID Rule
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Organization ID cannot be empty.")
                .NotNull().WithMessage("Organization ID is required.");

            // IsActive Rule - simplified validation since it's a boolean
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive status is required.");
            // Note: Booleans cannot be "empty" so we only need NotNull()
        }

        #endregion
    }
}
