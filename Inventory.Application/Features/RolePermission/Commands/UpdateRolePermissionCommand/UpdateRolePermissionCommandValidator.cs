using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.RolePermission.Commands.UpdateRolePermissionCommand
{
    public class UpdateRolePermissionCommandValidator : AbstractValidator<UpdateRolePermissionCommand>
    {
        #region Fields

        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IAppModuleRepository _appModuleRepository;
        private readonly IPermissionRepository _permissionRepository;

        #endregion

        #region Ctor

        public UpdateRolePermissionCommandValidator(
            IRolePermissionRepository rolePermissionRepository,
            IAppModuleRepository appModuleRepository,
            IPermissionRepository permissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _appModuleRepository = appModuleRepository;
            _permissionRepository = permissionRepository;

            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Role-permission assignment ID is required.");

            RuleFor(x => x.ModuleId)
                .NotEmpty().WithMessage("Module ID cannot be empty.")
                .NotNull().WithMessage("Module ID is required.")
                .MustAsync(ValidateIfModuleExists).WithMessage("Module does not exist or is inactive.");

            RuleFor(x => x.PermissionId)
                .NotEmpty().WithMessage("Permission ID cannot be empty.")
                .NotNull().WithMessage("Permission ID is required.")
                .MustAsync(ValidateIfPermissionExists).WithMessage("Permission does not exist or is inactive.");

            RuleFor(x => x)
                .MustAsync(ValidateIfAssignmentIsUnique).WithMessage("Role-permission assignment already exists.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfModuleExists(Guid moduleId, CancellationToken cancellationToken)
        {
            var module = await _appModuleRepository.GetActiveByIdAsync(moduleId, cancellationToken);
            return module != null;
        }

        private async Task<bool> ValidateIfPermissionExists(Guid permissionId, CancellationToken cancellationToken)
        {
            var permission = await _permissionRepository.GetActiveByIdAsync(permissionId, cancellationToken);
            return permission != null;
        }

        private async Task<bool> ValidateIfAssignmentIsUnique(UpdateRolePermissionCommand command, CancellationToken cancellationToken)
        {
            var existingAssignment = await _rolePermissionRepository.GetByIdToMutateAsync(command.Id, cancellationToken);
            if (existingAssignment == null) return true;

            // Only validate if module or permission is being changed
            if (existingAssignment.ModuleId == command.ModuleId && existingAssignment.PermissionId == command.PermissionId)
                return true;

            var exists = await _rolePermissionRepository.ActiveExistsByRoleModuleAndPermissionAsync(
                existingAssignment.RoleId,
                command.ModuleId,
                command.PermissionId,
                cancellationToken);
            return !exists;
        }

        #endregion
    }
}
