using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Commands.CreateBomItemDispositionCommand
{
    public class CreateBomItemDispositionCommandValidator
        : AbstractValidator<CreateBomItemDispositionCommand>
    {
        #region Fields

        private readonly IBomItemDispositionRepository _bomItemDispositionRepository;

        #endregion

        #region Ctor

        public CreateBomItemDispositionCommandValidator(IBomItemDispositionRepository bomItemDispositionRepository)
        {
            _bomItemDispositionRepository = bomItemDispositionRepository;

            RuleFor(x => x.BomItemId)
                .NotEmpty().WithMessage("BOM Item ID cannot be empty.")
                .NotNull().WithMessage("BOM Item ID is required.");

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
