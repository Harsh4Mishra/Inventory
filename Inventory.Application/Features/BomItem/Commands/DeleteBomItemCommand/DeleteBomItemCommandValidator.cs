using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Commands.DeleteBomItemCommand
{
    public class DeleteBomItemCommandValidator : AbstractValidator<DeleteBomItemCommand>
    {
        #region Ctor

        public DeleteBomItemCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
