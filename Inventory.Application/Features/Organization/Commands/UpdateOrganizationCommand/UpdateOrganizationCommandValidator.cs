using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.Organization.Commands.UpdateOrganizationCommand
{
    public class UpdateOrganizationCommandValidator : AbstractValidator<UpdateOrganizationCommand>
    {
        #region Fields

        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctor

        public UpdateOrganizationCommandValidator(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository ?? throw new ArgumentNullException(nameof(organizationRepository));

            // ID Rule
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Organization ID is required.")
                .NotNull().WithMessage("Organization ID cannot be null.");

            // Name Rules
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Organization name cannot be empty.")
                .NotNull().WithMessage("Organization name is required.")
                .MinimumLength(2).WithMessage("Organization name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Organization name cannot exceed 100 characters.")
                .MustAsync(BeUniqueName).WithMessage("An organization with this name already exists.");

            // Code Rules (optional)
            RuleFor(x => x.Code)
                .MaximumLength(20).WithMessage("Organization code cannot exceed 20 characters.")
                .MustAsync(BeUniqueCode).WithMessage("An organization with this code already exists.")
                .When(x => !string.IsNullOrWhiteSpace(x.Code));

            // Description Rules (optional)
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Organization description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
        }

        #endregion

        #region Methods

        private async Task<bool> BeUniqueName(UpdateOrganizationCommand command, string? organizationName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(organizationName))
                return true;

            var existingOrganization = await _organizationRepository.GetByNameAsync(organizationName.Trim(), cancellationToken);
            return existingOrganization == null || existingOrganization.Id == command.Id;
        }

        private async Task<bool> BeUniqueCode(UpdateOrganizationCommand command, string? code, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(code))
                return true;

            var existingOrganization = await _organizationRepository.GetByCodeAsync(code.Trim(), cancellationToken);
            return existingOrganization == null || existingOrganization.Id == command.Id;
        }

        #endregion
    }
}
