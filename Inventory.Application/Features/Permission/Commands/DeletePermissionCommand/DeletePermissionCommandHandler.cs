using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Permission.Commands.DeletePermissionCommand
{
    public class DeletePermissionCommandHandler
        : IRequestHandler<DeletePermissionCommand, Unit>
    {
        #region Fields

        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeletePermissionCommandHandler(
            IPermissionRepository permissionRepository,
            IUnitOfWork unitOfWork)
        {
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeletePermissionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the Permission or fail if it doesn't exist
                var permission = await _permissionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No permission found with Id '{request.Id}'.");

                //2. Remove and persist
                _permissionRepository.Remove(permission);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete permission: {ex.Message}");
            }
        }

        #endregion
    }
}
