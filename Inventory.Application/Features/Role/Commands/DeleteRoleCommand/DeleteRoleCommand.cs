using MediatR;

namespace Inventory.Application.Features.Role.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }

        #endregion
    }
}
