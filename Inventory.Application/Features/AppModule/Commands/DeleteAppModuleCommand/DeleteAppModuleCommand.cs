using MediatR;

namespace Inventory.Application.Features.AppModule.Commands.DeleteAppModuleCommand
{
    public class DeleteAppModuleCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }

        #endregion
    }
}
