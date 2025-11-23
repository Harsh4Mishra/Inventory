using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.DeleteMaterialStorageRuleCommand
{
    public class DeleteMaterialStorageRuleCommandValidator : AbstractValidator<DeleteMaterialStorageRuleCommand>
    {
        #region Ctor

        public DeleteMaterialStorageRuleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
