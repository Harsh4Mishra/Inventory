using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Commands.DeleteAisleCommand
{
    public class DeleteAisleCommandValidator
        : AbstractValidator<DeleteAisleCommand>
    {
        #region Ctor

        public DeleteAisleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
