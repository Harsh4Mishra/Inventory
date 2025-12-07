using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.Role.Commands.CreateRoleCommand
{
    public class CreateRoleCommandValidator
        : AbstractValidator<CreateRoleCommand>
    {
        #region Fields

        private readonly IRoleRepository _RoleRepository;

        #endregion

        #region Ctor

        public CreateRoleCommandValidator(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .MustAsync(RoleDoesNotExist).WithMessage("Role already exists");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description is required.")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");
        }

        #endregion

        #region Methods

        private async Task<bool> RoleDoesNotExist(string roleName, CancellationToken ct)
        {
            // Repository returns true = exists
            bool exists = await _RoleRepository.ExistsByNameAsync(roleName, ct);

            return !exists; // true = valid, false = validation fail
        }

        #endregion
    }
}
