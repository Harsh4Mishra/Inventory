using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.DeleteRolePermissionCommand
{
    public class DeleteRolePermissionCommandHandler
       : IRequestHandler<DeleteRolePermissionCommand, Unit>
    {
        #region Fields

        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteRolePermissionCommandHandler(
            IRolePermissionRepository rolePermissionRepository,
            IUnitOfWork unitOfWork)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteRolePermissionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the RolePermission or fail if it doesn't exist
                var rolePermission = await _rolePermissionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No role-permission assignment found with Id '{request.Id}'.");

                //2. Remove and persist
                _rolePermissionRepository.Remove(rolePermission);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete role-permission assignment: {ex.Message}");
            }
        }

        #endregion
    }
}
