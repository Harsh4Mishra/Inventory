using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Organization.Commands.UpdateOrganizationCommand
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, Unit>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateOrganizationCommandHandler(
            IUnitOfWork unitOfWork,
            IOrganizationRepository organizationRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _organizationRepository = organizationRepository ?? throw new ArgumentNullException(nameof(organizationRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing organization or fail if it doesn't exist
                var organization = await _organizationRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No organization found with Id '{request.Id}'.");

                // 2. Check if organization is soft deleted
                if (organization.DeletedOn != null)
                {
                    throw new InvalidOperationException("Cannot update a deleted organization.");
                }

                // 3. Check for duplicate name (if name is being changed)
                if (!string.Equals(organization.Name, request.Name, StringComparison.OrdinalIgnoreCase))
                {
                    var existingWithName = await _organizationRepository.GetByNameAsync(request.Name, cancellationToken);
                    if (existingWithName != null && existingWithName.Id != request.Id)
                    {
                        throw new InvalidOperationException($"An organization named '{request.Name}' already exists.");
                    }
                }

                // 4. Check for duplicate code (if code is being changed and provided)
                if (!string.Equals(organization.Code, request.Code, StringComparison.OrdinalIgnoreCase) &&
                    !string.IsNullOrWhiteSpace(request.Code))
                {
                    var existingWithCode = await _organizationRepository.GetByCodeAsync(request.Code, cancellationToken);
                    if (existingWithCode != null && existingWithCode.Id != request.Id)
                    {
                        throw new InvalidOperationException($"An organization with code '{request.Code}' already exists.");
                    }
                }

                // 5. Identify who's making the change
                var userName = "System"; // Replace with actual user identification
                // var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value 
                //     ?? throw new InvalidOperationException("Cannot determine the current user");

                // 6. Apply updates and persist the changes
                organization.Update(request.Name, request.Code, request.Description, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (InvalidOperationException)
            {
                throw; // Re-throw business rule violations
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update organization: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
