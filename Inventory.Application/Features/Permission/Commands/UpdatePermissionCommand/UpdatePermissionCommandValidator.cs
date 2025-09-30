using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.Permission.Commands.UpdatePermissionCommand
{
    public class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommand>
    {
        #region Fields

        private readonly IPermissionRepository _permissionRepository;

        #endregion

        #region Ctor

        public UpdatePermissionCommandValidator(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Permission ID is required.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code cannot be empty.")
                .NotNull().WithMessage("Code is required.")
                .MinimumLength(2).WithMessage("Code must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Code cannot exceed 50 characters.")
                .Matches("^[a-zA-Z0-9_]+$").WithMessage("Code can only contain letters, numbers, and underscores.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x)
                .MustAsync(ValidateIfCodeIsUniqueForTenant).WithMessage("Permission with this code already exists for the tenant.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfCodeIsUniqueForTenant(UpdatePermissionCommand command, CancellationToken cancellationToken)
        {
            var existingPermission = await _permissionRepository.GetByIdToMutateAsync(command.Id, cancellationToken);
            if (existingPermission == null) return true;

            // Only validate if code is being changed
            if (existingPermission.Code == command.Code) return true;

            var exists = await _permissionRepository.ActiveExistsByTenantAndCodeAsync(
                existingPermission.TenantId,
                command.Code,
                cancellationToken);
            return !exists;
        }

        #endregion
    }
}
