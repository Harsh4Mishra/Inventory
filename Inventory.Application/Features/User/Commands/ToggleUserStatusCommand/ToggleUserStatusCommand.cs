using MediatR;

namespace Inventory.Application.Features.User.Commands.ToggleUserStatusCommand
{
    public sealed record ToggleUserStatusCommand : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
