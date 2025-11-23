using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.DeleteWarehouseItemCommand
{
    public class DeleteWarehouseItemCommandValidator : AbstractValidator<DeleteWarehouseItemCommand>
    {
        #region Ctor

        public DeleteWarehouseItemCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
