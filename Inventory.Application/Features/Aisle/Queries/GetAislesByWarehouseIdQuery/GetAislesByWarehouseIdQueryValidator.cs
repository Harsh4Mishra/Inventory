using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Queries.GetAislesByWarehouseIdQuery
{
    public class GetAislesByWarehouseIdQueryValidator
        : AbstractValidator<GetAislesByWarehouseIdQuery>
    {
        #region Ctor

        public GetAislesByWarehouseIdQueryValidator()
        {
            RuleFor(x => x.WarehouseId)
                .NotEmpty().WithMessage("Warehouse Id cannot be empty.")
                .NotNull().WithMessage("Warehouse Id is required.");
        }

        #endregion
    }
}
