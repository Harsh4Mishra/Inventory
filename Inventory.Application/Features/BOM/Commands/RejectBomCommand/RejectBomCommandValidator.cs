using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.RejectBomCommand
{
    public class RejectBomCommandValidator : AbstractValidator<RejectBomCommand>
    {
        #region Constructor

        public RejectBomCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");
        }

        #endregion
    }
}
