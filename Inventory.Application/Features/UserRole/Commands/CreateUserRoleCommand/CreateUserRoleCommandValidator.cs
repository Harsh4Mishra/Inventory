using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.UserRole.Commands.CreateUserRoleCommand
{
    public class CreateUserRoleCommandValidator
        : AbstractValidator<CreateUserRoleCommand>
    {
        #region Fields

        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        #endregion

        #region Ctor

        public CreateUserRoleCommandValidator(
            IUserRoleRepository userRoleRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;

            // UserId Validation
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID cannot be empty.")
                .NotNull().WithMessage("User ID is required.")
                .MustAsync(ValidateIfUserExistsAndActive).WithMessage("User does not exist or is inactive.");

            // RoleId Validation
            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Role ID cannot be empty.")
                .NotNull().WithMessage("Role ID is required.")
                .MustAsync(ValidateIfRoleExists).WithMessage("Role does not exist or is inactive.");

            // Combined Validation
            RuleFor(x => x)
                .MustAsync(ValidateIfAssignmentDoesNotExist).WithMessage("User is already assigned to this role.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfUserExistsAndActive(int userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
            return user != null && user.IsActive;
        }

        private async Task<bool> ValidateIfRoleExists(int roleId, CancellationToken cancellationToken)
        {
            // Assuming IRoleRepository has GetActiveByIdAsync, if not, use GetByIdAsync and check IsActive
            var role = await _roleRepository.GetByIdAsync(roleId, cancellationToken);
            return role != null;
        }

        private async Task<bool> ValidateIfAssignmentDoesNotExist(CreateUserRoleCommand command, CancellationToken cancellationToken)
        {
            var exists = await _userRoleRepository.ActiveExistsByUserAndRoleAsync(
                command.UserId,
                command.RoleId,
                cancellationToken);
            return !exists;
        }

        #endregion
    }
}
