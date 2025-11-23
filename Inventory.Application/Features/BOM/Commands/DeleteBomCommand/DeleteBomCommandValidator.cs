using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.DeleteBomCommand
{
    public class DeleteBomCommandValidator : AbstractValidator<DeleteBomCommand>
    {
        #region Ctor

        public DeleteBomCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
