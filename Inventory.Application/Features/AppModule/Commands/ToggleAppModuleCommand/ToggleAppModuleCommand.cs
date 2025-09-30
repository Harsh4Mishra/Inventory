using MediatR;

namespace Inventory.Application.Features.AppModule.Commands.ToggleAppModuleCommand
{
    public class ToggleAppModuleCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
