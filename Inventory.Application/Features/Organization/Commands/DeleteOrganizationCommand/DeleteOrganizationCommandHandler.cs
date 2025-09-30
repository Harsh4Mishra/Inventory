using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.Organization.Commands.DeleteOrganizationCommand
{
    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, Unit>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public DeleteOrganizationCommandHandler(
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

        public async Task<Unit> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the organization or fail if it doesn't exist
                var organization = await _organizationRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No organization found with Id '{request.Id}'.");

                //2. Remove and persist
                _organizationRepository.Remove(organization);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (InvalidOperationException)
            {
                throw; // Re-throw business rule violations
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete organization: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
