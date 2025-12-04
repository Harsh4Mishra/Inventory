using MediatR;

namespace Inventory.Application.Features.Permission.Commands.UpdatePermissionCommand
{
    public class UpdatePermissionCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        #endregion
    }
}
