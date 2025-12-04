using MediatR;

namespace Inventory.Application.Features.UserRole.Commands.DeleteUserRoleCommand
{
    public class DeleteUserRoleCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }

        #endregion
    }
}
