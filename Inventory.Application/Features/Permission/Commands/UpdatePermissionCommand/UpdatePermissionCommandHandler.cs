using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Permission.Commands.UpdatePermissionCommand
{
    public class UpdatePermissionCommandHandler
        : IRequestHandler<UpdatePermissionCommand, Unit>
    {
        #region Fields

        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdatePermissionCommandHandler(
            IPermissionRepository permissionRepository,
            IUnitOfWork unitOfWork)
        {
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            UpdatePermissionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the Permission or fail if it doesn't exist
                var permission = await _permissionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No permission found with Id '{request.Id}'.");

                //2. Check if code is being changed and validate uniqueness
                if (permission.Code != request.Code)
                {
                    if (await _permissionRepository.ActiveExistsByTenantAndCodeAsync(permission.TenantId, request.Code, cancellationToken))
                    {
                        throw new InvalidOperationException($"A permission with code '{request.Code}' already exists for this tenant.");
                    }
                }

                //3. Update and persist
                permission.Update(request.Code, request.Name, request.Description, "System"); // TODO: Replace with actual user
                _permissionRepository.Update(permission);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update permission: {ex.Message}");
            }
        }

        #endregion
    }
}
