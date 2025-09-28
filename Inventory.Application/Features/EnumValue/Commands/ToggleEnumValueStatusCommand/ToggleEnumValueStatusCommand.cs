using MediatR;

namespace Inventory.Application.Features.EnumValue.Commands.ToggleEnumValueStatusCommand
{
    public sealed record ToggleEnumValueStatusCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid EnumTypeId { get; init; }
        public bool IsActive { get; init; }

        #endregion
    }
}
