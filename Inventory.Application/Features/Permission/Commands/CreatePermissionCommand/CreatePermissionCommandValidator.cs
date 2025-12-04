using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.Permission.Commands.CreatePermissionCommand
{
    public class CreatePermissionCommandValidator
        : AbstractValidator<CreatePermissionCommand>
    {
        #region Fields

        private readonly IPermissionRepository _permissionRepository;
        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctor

        public CreatePermissionCommandValidator(
            IPermissionRepository permissionRepository,
            IOrganizationRepository organizationRepository)
        {
            _permissionRepository = permissionRepository;
            _organizationRepository = organizationRepository;

            // TenantId Validation
            RuleFor(x => x.TenantId)
                .NotEmpty().WithMessage("Tenant ID cannot be empty.")
                .NotNull().WithMessage("Tenant ID is required.")
                .MustAsync(ValidateIfTenantExists).WithMessage("Tenant does not exist or is inactive.");

            // Code Validation
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code cannot be empty.")
                .NotNull().WithMessage("Code is required.")
                .MinimumLength(2).WithMessage("Code must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Code cannot exceed 50 characters.")
                .Matches("^[a-zA-Z0-9_]+$").WithMessage("Code can only contain letters, numbers, and underscores.");

            // Name Validation
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            // Description Validation
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            // Combined Validation
            RuleFor(x => x)
                .MustAsync(ValidateIfPermissionDoesNotExist).WithMessage("Permission with this code already exists for the tenant.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfTenantExists(int tenantId, CancellationToken cancellationToken)
        {
            var tenant = await _organizationRepository.GetActiveByIdAsync(tenantId, cancellationToken);
            return tenant != null;
        }

        private async Task<bool> ValidateIfPermissionDoesNotExist(CreatePermissionCommand command, CancellationToken cancellationToken)
        {
            var exists = await _permissionRepository.ActiveExistsByTenantAndCodeAsync(
                command.TenantId,
                command.Code,
                cancellationToken);
            return !exists;
        }

        #endregion
    }
}
