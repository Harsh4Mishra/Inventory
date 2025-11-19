using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.DeleteVerifiedMaterialCommand
{
    public class DeleteVerifiedMaterialCommandValidator : AbstractValidator<DeleteVerifiedMaterialCommand>
    {
        #region Ctor

        public DeleteVerifiedMaterialCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
