using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Permission.Commands.CreatePermissionCommand
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreatePermissionCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IPermissionRepository permissionRepository,
            IOrganizationRepository organizationRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _permissionRepository = permissionRepository;
            _organizationRepository = organizationRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreatePermissionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate tenant exists and is active
                var organization = await _organizationRepository.GetActiveByIdAsync(request.TenantId, cancellationToken);
                if (organization == null)
                {
                    throw new InvalidOperationException($"Organization with ID '{request.TenantId}' not found or inactive.");
                }

                // 2. Prevent duplicate permission codes within the same tenant
                if (await _permissionRepository.ActiveExistsByTenantAndCodeAsync(request.TenantId, request.Code, cancellationToken))
                {
                    throw new InvalidOperationException($"A permission with code '{request.Code}' already exists for this tenant.");
                }

                // 3. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Create and persist the new permission
                var permission = PermissionDO.Create(
                    request.TenantId,
                    request.Code,
                    request.Name,
                    request.Description,
                    userName);

                _permissionRepository.Add(permission);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return permission.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create permission: {ex.Message}");
            }
        }

        #endregion
    }
}
