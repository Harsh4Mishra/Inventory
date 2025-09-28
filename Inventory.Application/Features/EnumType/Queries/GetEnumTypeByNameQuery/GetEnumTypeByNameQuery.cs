using MediatR;

namespace Inventory.Application.Features.EnumType.Queries.GetEnumTypeByNameQuery
{
    public sealed record GetEnumTypeByNameQuery
        : IRequest<GetEnumTypeByNameQueryResult>
    {
        #region Properties

        public string Name { get; init; } = default!;

        #endregion
    }
}
