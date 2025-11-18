using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.DeleteMaterialCommand
{
    public class DeleteMaterialCommandValidator : AbstractValidator<DeleteMaterialCommand>
    {
        #region Ctor

        public DeleteMaterialCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
