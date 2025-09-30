using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.RolePermission.Commands.UpdateRolePermissionCommand
{
    public class UpdateRolePermissionCommandHandler
        : IRequestHandler<UpdateRolePermissionCommand, Unit>
    {
        #region Fields

        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IAppModuleRepository _appModuleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateRolePermissionCommandHandler(
            IRolePermissionRepository rolePermissionRepository,
            IAppModuleRepository appModuleRepository,
            IPermissionRepository permissionRepository,
            IUnitOfWork unitOfWork)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _appModuleRepository = appModuleRepository;
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            UpdateRolePermissionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the RolePermission or fail if it doesn't exist
                var rolePermission = await _rolePermissionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No role-permission assignment found with Id '{request.Id}'.");

                //2. Validate new module exists and is active
                var module = await _appModuleRepository.GetActiveByIdAsync(request.ModuleId, cancellationToken);
                if (module == null)
                {
                    throw new InvalidOperationException($"App module with ID '{request.ModuleId}' not found or inactive.");
                }

                //3. Validate new permission exists and is active
                var permission = await _permissionRepository.GetActiveByIdAsync(request.PermissionId, cancellationToken);
                if (permission == null)
                {
                    throw new InvalidOperationException($"Permission with ID '{request.PermissionId}' not found or inactive.");
                }

                //4. Check if assignment is being changed and validate uniqueness
                if (rolePermission.ModuleId != request.ModuleId || rolePermission.PermissionId != request.PermissionId)
                {
                    if (await _rolePermissionRepository.ActiveExistsByRoleModuleAndPermissionAsync(
                        rolePermission.RoleId, request.ModuleId, request.PermissionId, cancellationToken))
                    {
                        throw new InvalidOperationException($"This role-permission assignment already exists.");
                    }
                }

                //5. Update and persist
                rolePermission.Update(request.ModuleId, request.PermissionId, "System"); // TODO: Replace with actual user
                _rolePermissionRepository.Update(rolePermission);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update role-permission assignment: {ex.Message}");
            }
        }

        #endregion
    }
}
