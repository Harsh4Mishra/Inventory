using FluentValidation;

namespace Inventory.Application.Features.EnumValue.Queries.GetEnumValuesByEnumTypeIdQuery
{
    public class GetEnumValuesByEnumTypeIdQueryValidator
        : AbstractValidator<GetEnumValuesByEnumTypeIdQuery>
    {
        #region Ctor

        public GetEnumValuesByEnumTypeIdQueryValidator()
        {
            // Rule Writing
            RuleFor(x => x.EnumTypeId)
                .NotEmpty().WithMessage("Enum type ID cannot be empty.")
                .NotNull().WithMessage("Enum type ID is required.");
        }

        #endregion
    }
}
