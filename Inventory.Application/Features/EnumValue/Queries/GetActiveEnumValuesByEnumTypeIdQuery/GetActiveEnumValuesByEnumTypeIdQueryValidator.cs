using FluentValidation;

namespace Inventory.Application.Features.EnumValue.Queries.GetActiveEnumValuesByEnumTypeIdQuery
{
    public class GetActiveEnumValuesByEnumTypeIdQueryValidator
        : AbstractValidator<GetActiveEnumValuesByEnumTypeIdQuery>
    {
        #region Ctor

        public GetActiveEnumValuesByEnumTypeIdQueryValidator()
        {
            // Rule Writing
            RuleFor(x => x.EnumTypeId)
                .NotEmpty().WithMessage("Enum type ID cannot be empty.")
                .NotNull().WithMessage("Enum type ID is required.");
        }

        #endregion
    }
}
