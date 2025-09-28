using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.Organization.Commands.CreateOrganizationCommand
{
    public class CreateOrganizationCommandHandler
        : IRequestHandler<CreateOrganizationCommand, Guid>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctor

        public CreateOrganizationCommandHandler(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IOrganizationRepository organizationRepository)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Methods

        public async Task<Guid> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates by name
                if (await _organizationRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"An organization named '{request.Name}' already exists.");
                }

                // 2. Prevent duplicates by code (if code is provided)
                var code = "ORG001"; //work on this

                // 3. Identify the creator
                var userName = "System"; // Replace with actual user identification
                // var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value 
                //     ?? throw new InvalidOperationException("Could not determine the current user.");

                // 4. Create and persist the new Organization
                var organization = OrganizationDO.Create(
                    request.Name,
                    code,
                    request.Description,
                    userName);

                _organizationRepository.Add(organization);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return organization.Id;
            }
            catch (InvalidOperationException)
            {
                throw; // Re-throw business rule violations
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create organization: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
