using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Commands.DeleteTrayCommand
{
    public class DeleteTrayCommandValidator : AbstractValidator<DeleteTrayCommand>
    {
        #region Ctor

        public DeleteTrayCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.AisleId).NotEmpty().NotNull();
            RuleFor(x => x.RowLocId).NotEmpty().NotNull();
        }

        #endregion
    }
}
