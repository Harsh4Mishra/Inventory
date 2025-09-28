using MediatR;

namespace Inventory.Application.Features.EnumValue.Commands.UpdateEnumValueCommand
{
    public class UpdateEnumValueCommand : IRequest<Unit>
    {
        #region properties

        public Guid Id { get; init; } = default;
        public Guid EnumTypeId { get; init; } = default;
        public string Name { get; init; } = default!;
        public string? Description { get; init; }

        #endregion
    }
}
