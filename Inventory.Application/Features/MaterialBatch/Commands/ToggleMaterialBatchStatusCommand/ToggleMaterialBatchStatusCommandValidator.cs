using FluentValidation;

namespace Inventory.Application.Features.MaterialBatch.Commands.ToggleMaterialBatchStatusCommand
{
    public class ToggleMaterialBatchStatusCommandValidator : AbstractValidator<ToggleMaterialBatchStatusCommand>
    {
        #region Constructor

        public ToggleMaterialBatchStatusCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.IsActive)
                .NotEmpty().WithMessage("Status is required.")
                .NotNull().WithMessage("Status cannot be null.");
        }

        #endregion
    }
}
