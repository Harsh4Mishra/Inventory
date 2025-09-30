using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.AppModule.Commands.UpdateAppModuleCommand
{
    public class UpdateAppModuleCommandValidator : AbstractValidator<UpdateAppModuleCommand>
    {
        #region Fields

        private readonly IAppModuleRepository _appModuleRepository;

        #endregion

        #region Ctor

        public UpdateAppModuleCommandValidator(IAppModuleRepository appModuleRepository)
        {
            _appModuleRepository = appModuleRepository;

            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("App module ID is required.");

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
                .MustAsync(ValidateIfCodeIsUniqueForTenant).WithMessage("App module with this code already exists for the tenant.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfCodeIsUniqueForTenant(UpdateAppModuleCommand command, CancellationToken cancellationToken)
        {
            var existingModule = await _appModuleRepository.GetByIdToMutateAsync(command.Id, cancellationToken);
            if (existingModule == null) return true;

            // Only validate if code is being changed
            if (existingModule.Code == command.Code) return true;

            var exists = await _appModuleRepository.ActiveExistsByTenantAndCodeAsync(
                existingModule.TenantId,
                command.Code,
                cancellationToken);
            return !exists;
        }

        #endregion
    }
}
