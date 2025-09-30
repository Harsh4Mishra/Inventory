using FluentValidation;

namespace Inventory.Application.Features.AppModule.Commands.ToggleAppModuleCommand
{
    public class ToggleAppModuleCommandValidator : AbstractValidator<ToggleAppModuleCommand>
    {
        #region Ctor

        public ToggleAppModuleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("App module ID is required.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive status is required.");
        }

        #endregion
    }
}
