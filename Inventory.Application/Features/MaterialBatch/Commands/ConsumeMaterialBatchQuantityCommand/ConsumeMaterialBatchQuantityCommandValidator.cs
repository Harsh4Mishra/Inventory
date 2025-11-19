using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.ConsumeMaterialBatchQuantityCommand
{
    public class ConsumeMaterialBatchQuantityCommandValidator : AbstractValidator<ConsumeMaterialBatchQuantityCommand>
    {
        #region Ctor

        public ConsumeMaterialBatchQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.ConsumedQuantity)
                .GreaterThan(0).WithMessage("Consumed quantity must be greater than zero.");
        }

        #endregion
    }
}
