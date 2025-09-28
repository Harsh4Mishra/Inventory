using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Organization.Queries.GetOrganizationQuery
{
    public class GetOrganizationQueryHandler
        : IRequestHandler<GetOrganizationQuery, IEnumerable<GetOrganizationQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctor

        public GetOrganizationQueryHandler(
            IMapper mapper,
            IOrganizationRepository organizationRepository)
        {
            _mapper = mapper;
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetOrganizationQueryResult>> Handle(
            GetOrganizationQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all Organization
                var result = await _organizationRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetOrganizationQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve Organization " + ex.Message);
            }
        }

        #endregion
    }
}
