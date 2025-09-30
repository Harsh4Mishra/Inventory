using FluentValidation;

namespace Inventory.Application.Features.AppModule.Commands.DeleteAppModuleCommand
{
    public class DeleteAppModuleCommandValidator : AbstractValidator<DeleteAppModuleCommand>
    {
        #region Ctor

        public DeleteAppModuleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("App module ID is required.");
        }

        #endregion
    }
}
