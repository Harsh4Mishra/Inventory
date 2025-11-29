using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        #region Ctor

        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
