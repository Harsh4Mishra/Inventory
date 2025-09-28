using MediatR;

namespace Inventory.Application.Features.User.Commands.ToggleUserStatusCommand
{
    public sealed record ToggleUserStatusCommand : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; init; }
        public bool IsActive { get; init; }

        #endregion
    }
}
