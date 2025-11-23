using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Commands.CreateBomItemCommand
{
    public class CreateBomItemCommandValidator : AbstractValidator<CreateBomItemCommand>
    {
        #region Ctor

        public CreateBomItemCommandValidator()
        {
            RuleFor(x => x.BomId)
                .NotEmpty().WithMessage("BOM ID is required.")
                .NotNull().WithMessage("BOM ID cannot be null.");

            RuleFor(x => x.MaterialBatchId)
                .NotEmpty().WithMessage("Material Batch ID is required.")
                .NotNull().WithMessage("Material Batch ID cannot be null.");

            RuleFor(x => x.WarehouseItemId)
                .NotEmpty().WithMessage("Warehouse Item ID is required.")
                .NotNull().WithMessage("Warehouse Item ID cannot be null.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .NotEmpty().WithMessage("Quantity is required.");
        }

        #endregion
    }
}
