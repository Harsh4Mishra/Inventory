using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.UpdateMaterialBatchQuantityCommand
{
    public class UpdateMaterialBatchQuantityCommandValidator : AbstractValidator<UpdateMaterialBatchQuantityCommand>
    {
        #region Ctor

        public UpdateMaterialBatchQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.NewQuantity)
                .GreaterThan(0).WithMessage("New quantity must be greater than zero.");
        }

        #endregion
    }
}
