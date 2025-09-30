using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.AppModule.Commands.ToggleAppModuleCommand
{
    public class ToggleAppModuleCommandHandler
        : IRequestHandler<ToggleAppModuleCommand, Unit>
    {
        #region Fields

        private readonly IAppModuleRepository _appModuleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public ToggleAppModuleCommandHandler(
            IAppModuleRepository appModuleRepository,
            IUnitOfWork unitOfWork)
        {
            _appModuleRepository = appModuleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            ToggleAppModuleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the AppModule or fail if it doesn't exist
                var appModule = await _appModuleRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No app module found with Id '{request.Id}'.");

                //2. Toggle status
                if (request.IsActive)
                {
                    appModule.Activate("System"); // TODO: Replace with actual user
                }
                else
                {
                    appModule.Deactivate("System"); // TODO: Replace with actual user
                }

                //3. Update and persist
                _appModuleRepository.Update(appModule);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to toggle app module status: {ex.Message}");
            }
        }

        #endregion
    }
}
