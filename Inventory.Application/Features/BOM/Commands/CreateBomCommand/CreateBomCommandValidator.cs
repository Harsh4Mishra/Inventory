using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.CreateBomCommand
{
    public class CreateBomCommandValidator : AbstractValidator<CreateBomCommand>
    {
        #region Fields

        private readonly IBomRepository _bomRepository;

        #endregion

        #region Ctor

        public CreateBomCommandValidator(IBomRepository bomRepository)
        {
            _bomRepository = bomRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .MustAsync(ValidateIfBomDoesNotExist).WithMessage("BOM already exists");

            RuleFor(x => x.BomCategoryId)
                .NotEmpty().WithMessage("BOM Category ID is required.")
                .NotNull().WithMessage("BOM Category ID cannot be null.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfBomDoesNotExist(string? name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            return !await _bomRepository.ExistsByNameAsync(name, cancellationToken);
        }

        #endregion
    }
}
