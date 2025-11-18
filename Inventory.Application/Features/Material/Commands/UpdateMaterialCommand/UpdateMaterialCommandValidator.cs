using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.UpdateMaterialCommand
{
    public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
    {
        #region Ctor

        public UpdateMaterialCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Category)
                .MaximumLength(50).WithMessage("Category cannot exceed 50 characters.");

            RuleFor(x => x.Subcategory)
                .MaximumLength(50).WithMessage("Subcategory cannot exceed 50 characters.");

            RuleFor(x => x.CasNumber)
                .MaximumLength(20).WithMessage("CAS Number cannot exceed 20 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }

        #endregion
    }
}
