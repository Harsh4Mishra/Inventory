using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Organization.Commands.ToggleOrganizationStatusCommand
{
    public sealed class ToggleOrganizationStatusCommandHandler
        : IRequestHandler<ToggleOrganizationStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public ToggleOrganizationStatusCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IOrganizationRepository organizationRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _organizationRepository = organizationRepository ?? throw new ArgumentNullException(nameof(organizationRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(ToggleOrganizationStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the Organization or fail if it doesn't exist
                var organization = await _organizationRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No organization found with Id '{request.Id}'.");

                // 2. Check if organization is soft deleted
                if (organization.DeletedOn != null)
                {
                    throw new InvalidOperationException("Cannot toggle status of a deleted organization. Restore it first.");
                }

                // 3. Check if the status is already in the desired state
                if (organization.IsActive == request.IsActive)
                {
                    throw new InvalidOperationException($"Organization is already {(request.IsActive ? "active" : "inactive")}.");
                }

                // 4. Identify who's performing the toggle
                var userName = "System"; // Replace with actual user identification
                // var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value 
                //     ?? throw new InvalidOperationException("Cannot determine the current user");

                // 5. Toggle status
                if (request.IsActive)
                {
                    organization.Activate(userName);
                }
                else
                {
                    organization.Deactivate(userName);
                }

                // 6. Persist changes
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (InvalidOperationException)
            {
                throw; // Re-throw business rule violations
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to toggle organization status: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
