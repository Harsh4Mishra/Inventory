using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.DeleteStorageSectionCommand
{
    public class DeleteStorageSectionCommandValidator : AbstractValidator<DeleteStorageSectionCommand>
    {
        #region Ctor

        public DeleteStorageSectionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
