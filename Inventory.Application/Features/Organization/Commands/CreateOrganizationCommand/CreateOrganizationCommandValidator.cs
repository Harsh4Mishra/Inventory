using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Organization.Commands.CreateOrganizationCommand
{
    public class CreateOrganizationCommandValidator
        : AbstractValidator<CreateOrganizationCommand>
    {
        #region Fields

        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctor

        public CreateOrganizationCommandValidator(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;

            // Name Rules
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Organization name cannot be empty.")
                .NotNull().WithMessage("Organization name is required.")
                .MinimumLength(2).WithMessage("Organization name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Organization name cannot exceed 100 characters.")
                .MustAsync(BeUniqueName).WithMessage("An organization with this name already exists.");


            // Description Rules (optional)
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Organization description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
        }

        #endregion

        #region Methods

        private async Task<bool> BeUniqueName(string? organizationName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(organizationName))
                return true;

            var existingOrganization = await _organizationRepository.GetByNameAsync(organizationName.Trim(), cancellationToken);
            return existingOrganization == null;
        }

        private async Task<bool> BeUniqueCode(string? code, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(code))
                return true;

            var existingOrganization = await _organizationRepository.GetByCodeAsync(code.Trim(), cancellationToken);
            return existingOrganization == null;
        }

        #endregion
    }
}
