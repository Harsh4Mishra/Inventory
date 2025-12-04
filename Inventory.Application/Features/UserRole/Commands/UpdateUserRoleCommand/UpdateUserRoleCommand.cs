using MediatR;

namespace Inventory.Application.Features.UserRole.Commands.UpdateUserRoleCommand
{
    public class UpdateUserRoleCommand
       : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }
        public int RoleId { get; set; }

        #endregion
    }
}
