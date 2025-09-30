using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RolePermission.Commands.CreateRolePermissionCommand
{
    public class CreateRolePermissionCommandValidator
        : AbstractValidator<CreateRolePermissionCommand>
    {
        #region Fields

        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAppModuleRepository _appModuleRepository;
        private readonly IPermissionRepository _permissionRepository;

        #endregion

        #region Ctor

        public CreateRolePermissionCommandValidator(
            IRolePermissionRepository rolePermissionRepository,
            IRoleRepository roleRepository,
            IAppModuleRepository appModuleRepository,
            IPermissionRepository permissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _roleRepository = roleRepository;
            _appModuleRepository = appModuleRepository;
            _permissionRepository = permissionRepository;

            // RoleId Validation
            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Role ID cannot be empty.")
                .NotNull().WithMessage("Role ID is required.")
                .MustAsync(ValidateIfRoleExists).WithMessage("Role does not exist or is inactive.");

            // ModuleId Validation
            RuleFor(x => x.ModuleId)
                .NotEmpty().WithMessage("Module ID cannot be empty.")
                .NotNull().WithMessage("Module ID is required.")
                .MustAsync(ValidateIfModuleExists).WithMessage("Module does not exist or is inactive.");

            // PermissionId Validation
            RuleFor(x => x.PermissionId)
                .NotEmpty().WithMessage("Permission ID cannot be empty.")
                .NotNull().WithMessage("Permission ID is required.")
                .MustAsync(ValidateIfPermissionExists).WithMessage("Permission does not exist or is inactive.");

            // Combined Validation
            RuleFor(x => x)
                .MustAsync(ValidateIfAssignmentDoesNotExist).WithMessage("Role-permission assignment already exists.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfRoleExists(Guid roleId, CancellationToken cancellationToken)
        {
            var role = (await _roleRepository.GetAllActiveAsync(cancellationToken)).Where(propa=>propa.Id==roleId).FirstOrDefault();
            return role != null;
        }

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

        private async Task<bool> ValidateIfAssignmentDoesNotExist(CreateRolePermissionCommand command, CancellationToken cancellationToken)
        {
            var exists = await _rolePermissionRepository.ActiveExistsByRoleModuleAndPermissionAsync(
                command.RoleId,
                command.ModuleId,
                command.PermissionId,
                cancellationToken);
            return !exists;
        }

        #endregion
    }
}
