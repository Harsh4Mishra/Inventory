using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Commands.DeleteRowLocCommand
{
    public class DeleteRowLocCommandValidator : AbstractValidator<DeleteRowLocCommand>
    {
        #region Ctor

        public DeleteRowLocCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.AisleId).NotEmpty().NotNull();
        }

        #endregion
    }
}
