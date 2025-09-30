using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.RolePermission.Commands.CreateRolePermissionCommand
{
    public class CreateRolePermissionCommandHandler : IRequestHandler<CreateRolePermissionCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAppModuleRepository _appModuleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateRolePermissionCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IRolePermissionRepository rolePermissionRepository,
            IRoleRepository roleRepository,
            IAppModuleRepository appModuleRepository,
            IPermissionRepository permissionRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _rolePermissionRepository = rolePermissionRepository;
            _roleRepository = roleRepository;
            _appModuleRepository = appModuleRepository;
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Guid> Handle(
            CreateRolePermissionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate role exists and is active
                var role = (await _roleRepository.GetAllActiveAsync(cancellationToken)).Where(propa => propa.Id == request.RoleId).FirstOrDefault();
                if (role == null)
                {
                    throw new InvalidOperationException($"Role with ID '{request.RoleId}' not found or inactive.");
                }

                // 2. Validate module exists and is active
                var module = await _appModuleRepository.GetActiveByIdAsync(request.ModuleId, cancellationToken);
                if (module == null)
                {
                    throw new InvalidOperationException($"App module with ID '{request.ModuleId}' not found or inactive.");
                }

                // 3. Validate permission exists and is active
                var permission = await _permissionRepository.GetActiveByIdAsync(request.PermissionId, cancellationToken);
                if (permission == null)
                {
                    throw new InvalidOperationException($"Permission with ID '{request.PermissionId}' not found or inactive.");
                }

                // 4. Prevent duplicate assignments
                if (await _rolePermissionRepository.ActiveExistsByRoleModuleAndPermissionAsync(
                    request.RoleId, request.ModuleId, request.PermissionId, cancellationToken))
                {
                    throw new InvalidOperationException($"This role-permission assignment already exists.");
                }

                // 5. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System"; // TODO: Replace with actual user identification

                // 6. Create and persist the new role-permission assignment
                var rolePermission = RolePermissionDO.Create(
                    request.RoleId,
                    request.ModuleId,
                    request.PermissionId,
                    userName);

                _rolePermissionRepository.Add(rolePermission);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return rolePermission.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create role-permission assignment: {ex.Message}");
            }
        }

        #endregion
    }
}
