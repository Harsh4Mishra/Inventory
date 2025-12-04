using MediatR;

namespace Inventory.Application.Features.EnumType.Queries.GetEnumTypeByIdQuery
{
    public sealed record GetEnumTypeByIdQuery
        : IRequest<GetEnumTypeByIdQueryResult>
    {
        #region Properties

        public int Id { get; init; }

        #endregion
    }
}
