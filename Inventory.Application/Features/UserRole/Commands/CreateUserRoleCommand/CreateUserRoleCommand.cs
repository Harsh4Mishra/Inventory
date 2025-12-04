using MediatR;

namespace Inventory.Application.Features.UserRole.Commands.CreateUserRoleCommand
{
    public sealed record CreateUserRoleCommand : IRequest<int>
    {
        #region Properties
        public int UserId { get; set; }
        public int RoleId { get; set; }
        #endregion
    }
}
