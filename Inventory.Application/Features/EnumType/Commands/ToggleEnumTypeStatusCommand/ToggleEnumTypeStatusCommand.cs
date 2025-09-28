using MediatR;

namespace Inventory.Application.Features.EnumType.Commands.ToggleEnumTypeStatusCommand
{
    public sealed record ToggleEnumTypeStatusCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; init; }
        public bool IsActive { get; init; }

        #endregion
    }
}
