using MediatR;

namespace Inventory.Application.Features.Permission.Commands.DeletePermissionCommand
{
    public class DeletePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }

        #endregion
    }
}
