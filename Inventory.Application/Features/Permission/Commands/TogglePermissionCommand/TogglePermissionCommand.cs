using MediatR;

namespace Inventory.Application.Features.Permission.Commands.TogglePermissionCommand
{
    public class TogglePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
