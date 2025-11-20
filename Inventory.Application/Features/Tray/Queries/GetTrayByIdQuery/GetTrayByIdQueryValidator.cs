using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Queries.GetTrayByIdQuery
{
    public class GetTrayByIdQueryValidator
        : AbstractValidator<GetTrayByIdQuery>
    {
        #region Ctor

        public GetTrayByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Tray Id cannot be empty.")
                .NotNull().WithMessage("Tray Id is required.");
        }

        #endregion
    }
}
