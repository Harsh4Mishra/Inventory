using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Commands.UpdateBomItemDispositionCommand
{
    public class UpdateBomItemDispositionCommandValidator : AbstractValidator<UpdateBomItemDispositionCommand>
    {
        #region Ctor

        public UpdateBomItemDispositionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID cannot be empty.")
                .NotNull().WithMessage("ID is required.");

            RuleFor(x => x.Disposition)
                .NotEmpty().WithMessage("Disposition cannot be empty.")
                .NotNull().WithMessage("Disposition is required.")
                .Must(BeValidDisposition).WithMessage("Disposition must be one of: accept, rework, scrap");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");
        }

        #endregion

        #region Methods

        private bool BeValidDisposition(string disposition)
        {
            var validDispositions = new[] { "accept", "rework", "scrap" };
            return validDispositions.Contains(disposition?.ToLowerInvariant());
        }

        #endregion
    }
}
