using MediatR;

namespace Inventory.Application.Features.EnumValue.Commands.ToggleEnumValueStatusCommand
{
    public sealed record ToggleEnumValueStatusCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; init; }
        public int EnumTypeId { get; init; }
        public bool IsActive { get; init; }

        #endregion
    }
}
