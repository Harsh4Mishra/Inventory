using MediatR;

namespace Inventory.Application.Features.Role.Commands.UpdateRoleCommand
{
    public sealed record UpdateRoleCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        #endregion
    }
}
