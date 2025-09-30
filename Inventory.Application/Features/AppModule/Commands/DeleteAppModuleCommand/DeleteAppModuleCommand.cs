using MediatR;

namespace Inventory.Application.Features.AppModule.Commands.DeleteAppModuleCommand
{
    public class DeleteAppModuleCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }

        #endregion
    }
}
