using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.AppModule.Commands.CreateAppModuleCommand
{
    public class CreateAppModuleCommandHandler : IRequestHandler<CreateAppModuleCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppModuleRepository _appModuleRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateAppModuleCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IAppModuleRepository appModuleRepository,
            IOrganizationRepository organizationRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _appModuleRepository = appModuleRepository;
            _organizationRepository = organizationRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Guid> Handle(
            CreateAppModuleCommand request,
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

                // 2. Prevent duplicate module codes within the same tenant
                if (await _appModuleRepository.ActiveExistsByTenantAndCodeAsync(request.TenantId, request.Code, cancellationToken))
                {
                    throw new InvalidOperationException($"An app module with code '{request.Code}' already exists for this tenant.");
                }

                // 3. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Create and persist the new app module
                var appModule = AppModuleDO.Create(
                    request.TenantId,
                    request.Code,
                    request.Name,
                    request.Description,
                    userName);

                _appModuleRepository.Add(appModule);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return appModule.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create app module: {ex.Message}");
            }
        }

        #endregion
    }
}
