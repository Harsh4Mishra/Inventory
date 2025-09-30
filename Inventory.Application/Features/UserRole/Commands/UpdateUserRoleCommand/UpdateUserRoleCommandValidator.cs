using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.UserRole.Commands.UpdateUserRoleCommand
{
    public class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;

        #endregion

        #region Ctor

        public UpdateUserRoleCommandValidator(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("User-role assignment ID is required.");
            RuleFor(x => x.RoleId).NotEmpty().NotNull().WithMessage("Role ID is required.");
            RuleFor(x => x.RoleId).MustAsync(ValidateIfRoleExists).WithMessage("Role does not exist or is inactive.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfRoleExists(Guid roleId, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(roleId, cancellationToken);
            return role != null;
        }

        #endregion
    }
}
