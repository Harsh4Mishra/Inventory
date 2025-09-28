using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Organization.Queries.GetActiveOrganizationQuery
{
    public class GetActiveOrganizationQueryHandler
        : IRequestHandler<GetActiveOrganizationQuery, IEnumerable<GetActiveOrganizationQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctor

        public GetActiveOrganizationQueryHandler(
            IMapper mapper,
            IOrganizationRepository organizationRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _organizationRepository = organizationRepository ?? throw new ArgumentNullException(nameof(organizationRepository));
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetActiveOrganizationQueryResult>> Handle(
            GetActiveOrganizationQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all organizations that are currently active and not deleted
                var organizations = await _organizationRepository.GetAllActiveAsync(cancellationToken);

                // 2. Filter out any soft deleted organizations (additional safety check)
                var activeOrganizations = organizations.Where(o => o.DeletedOn == null);

                // 3. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveOrganizationQueryResult>>(activeOrganizations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active organizations: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
