using MediatR;

namespace Inventory.Application.Features.EnumType.Queries.GetEnumTypeByIdQuery
{
    public sealed record GetEnumTypeByIdQuery
        : IRequest<GetEnumTypeByIdQueryResult>
    {
        #region Properties

        public Guid Id { get; init; }

        #endregion
    }
}
