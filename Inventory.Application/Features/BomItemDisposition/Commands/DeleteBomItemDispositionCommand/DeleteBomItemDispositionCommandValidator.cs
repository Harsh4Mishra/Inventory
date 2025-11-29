using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Commands.DeleteBomItemDispositionCommand
{
    public class DeleteBomItemDispositionCommandValidator : AbstractValidator<DeleteBomItemDispositionCommand>
    {
        #region Ctor

        public DeleteBomItemDispositionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
