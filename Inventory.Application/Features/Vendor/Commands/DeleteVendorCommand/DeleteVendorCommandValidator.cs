using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Commands.DeleteVendorCommand
{
    public class DeleteVendorCommandValidator : AbstractValidator<DeleteVendorCommand>
    {
        #region Ctor

        public DeleteVendorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
