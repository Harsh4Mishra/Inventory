using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Commands.DeleteBomCategoryCommand
{
    public class DeleteBomCategoryCommandValidator : AbstractValidator<DeleteBomCategoryCommand>
    {
        #region Ctor

        public DeleteBomCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
