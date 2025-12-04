using MediatR;

namespace Inventory.Application.Features.Role.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }

        #endregion
    }
}
