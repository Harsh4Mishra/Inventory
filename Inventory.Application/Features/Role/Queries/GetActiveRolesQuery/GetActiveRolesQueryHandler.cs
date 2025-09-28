using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Role.Queries.GetActiveRolesQuery
{
    public class GetActiveRolesQueryHandler : IRequestHandler<GetActiveRolesQuery, IEnumerable<GetActiveRolesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        #endregion

        #region Constructor

        public GetActiveRolesQueryHandler(
            IMapper mapper,
            IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveRolesQueryResult>> Handle(
            GetActiveRolesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all industries that are currently active
                var roles = await _roleRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveRolesQueryResult>>(roles);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active roles: {ex.Message}");
            }
        }

        #endregion
    }
}
