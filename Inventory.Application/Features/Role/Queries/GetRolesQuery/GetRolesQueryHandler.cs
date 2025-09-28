using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Role.Queries.GetRolesQuery
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IEnumerable<GetRolesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        #endregion

        #region Constructor

        public GetRolesQueryHandler(
            IMapper mapper,
            IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetRolesQueryResult>> Handle(
            GetRolesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all industries
                var roles = await _roleRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetRolesQueryResult>>(roles);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve roles: {ex.Message}");
            }
        }

        #endregion
    }
}
