using MediatR;

namespace Inventory.Application.Features.Role.Commands.ToggleRoleStatusCommand
{
    public sealed record ToggleRoleStatusCommand : IRequest<Unit>
    {
        #region Properties

        public int Id { get; init; }
        public bool IsActive { get; init; }

        #endregion
    }
}
