using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.DeleteMaterialBatchCommand
{
    public class DeleteMaterialBatchCommandValidator : AbstractValidator<DeleteMaterialBatchCommand>
    {
        #region Ctor

        public DeleteMaterialBatchCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
