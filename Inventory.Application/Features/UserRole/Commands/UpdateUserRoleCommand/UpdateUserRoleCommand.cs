using MediatR;

namespace Inventory.Application.Features.UserRole.Commands.UpdateUserRoleCommand
{
    public class UpdateUserRoleCommand
       : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid RoleId { get; set; }

        #endregion
    }
}
