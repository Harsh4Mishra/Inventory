using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Commands.CreateBomCategoryCommand
{
    public class CreateBomCategoryCommandValidator : AbstractValidator<CreateBomCategoryCommand>
    {
        #region Fields

        private readonly IBomCategoryRepository _bomCategoryRepository;

        #endregion

        #region Ctor

        public CreateBomCategoryCommandValidator(IBomCategoryRepository bomCategoryRepository)
        {
            _bomCategoryRepository = bomCategoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .MustAsync(ValidateIfBomCategoryDoesNotExist).WithMessage("BOM category already exists");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfBomCategoryDoesNotExist(string? name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            return !await _bomCategoryRepository.ExistsByNameAsync(name, cancellationToken);
        }

        #endregion
    }
}
