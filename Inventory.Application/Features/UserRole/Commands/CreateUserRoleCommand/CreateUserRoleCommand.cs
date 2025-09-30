using MediatR;

namespace Inventory.Application.Features.UserRole.Commands.CreateUserRoleCommand
{
    public sealed record CreateUserRoleCommand : IRequest<Guid>
    {
        #region Properties
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        #endregion
    }
}
