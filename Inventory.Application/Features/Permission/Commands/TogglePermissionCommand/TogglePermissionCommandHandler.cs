using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Permission.Commands.TogglePermissionCommand
{
    public class TogglePermissionCommandHandler
        : IRequestHandler<TogglePermissionCommand, Unit>
    {
        #region Fields

        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public TogglePermissionCommandHandler(
            IPermissionRepository permissionRepository,
            IUnitOfWork unitOfWork)
        {
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            TogglePermissionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the Permission or fail if it doesn't exist
                var permission = await _permissionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No permission found with Id '{request.Id}'.");

                //2. Toggle status
                if (request.IsActive)
                {
                    permission.Activate("System"); // TODO: Replace with actual user
                }
                else
                {
                    permission.Deactivate("System"); // TODO: Replace with actual user
                }

                //3. Update and persist
                _permissionRepository.Update(permission);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to toggle permission status: {ex.Message}");
            }
        }

        #endregion
    }
}
