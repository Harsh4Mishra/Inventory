using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Commands.UpdateBomCategoryCommand
{
    public class UpdateBomCategoryCommandValidator : AbstractValidator<UpdateBomCategoryCommand>
    {
        #region Ctor

        public UpdateBomCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID cannot be null.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
        }

        #endregion
    }
}
