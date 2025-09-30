using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.AppModule.Commands.UpdateAppModuleCommand
{
    public class UpdateAppModuleCommandHandler
        : IRequestHandler<UpdateAppModuleCommand, Unit>
    {
        #region Fields

        private readonly IAppModuleRepository _appModuleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateAppModuleCommandHandler(
            IAppModuleRepository appModuleRepository,
            IUnitOfWork unitOfWork)
        {
            _appModuleRepository = appModuleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            UpdateAppModuleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the AppModule or fail if it doesn't exist
                var appModule = await _appModuleRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No app module found with Id '{request.Id}'.");

                //2. Check if code is being changed and validate uniqueness
                if (appModule.Code != request.Code)
                {
                    if (await _appModuleRepository.ActiveExistsByTenantAndCodeAsync(appModule.TenantId, request.Code, cancellationToken))
                    {
                        throw new InvalidOperationException($"An app module with code '{request.Code}' already exists for this tenant.");
                    }
                }

                //3. Update and persist
                appModule.Update(request.Code, request.Name, request.Description, "System"); // TODO: Replace with actual user
                _appModuleRepository.Update(appModule);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update app module: {ex.Message}");
            }
        }

        #endregion
    }

}