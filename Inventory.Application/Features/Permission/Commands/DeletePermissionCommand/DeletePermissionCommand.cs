using MediatR;

namespace Inventory.Application.Features.Permission.Commands.DeletePermissionCommand
{
    public class DeletePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }

        #endregion
    }
}
