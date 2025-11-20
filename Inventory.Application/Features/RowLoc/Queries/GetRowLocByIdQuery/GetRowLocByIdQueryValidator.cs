using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Queries.GetRowLocByIdQuery
{
    public class GetRowLocByIdQueryValidator
        : AbstractValidator<GetRowLocByIdQuery>
    {
        #region Ctor

        public GetRowLocByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Row Location Id cannot be empty.")
                .NotNull().WithMessage("Row Location Id is required.");
        }

        #endregion
    }
}
