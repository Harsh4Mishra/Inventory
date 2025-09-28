
using MediatR;

namespace Inventory.Application.Features.Role.Commands.CreateRoleCommand
{
    public sealed record CreateRoleCommand : IRequest<Guid>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        #endregion
    }
}
