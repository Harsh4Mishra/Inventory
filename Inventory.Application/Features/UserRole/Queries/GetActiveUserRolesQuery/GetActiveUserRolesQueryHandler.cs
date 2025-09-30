using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.UserRole.Queries.GetActiveUserRolesQuery
{
    public class GetActiveUserRolesQueryHandler : IRequestHandler<GetActiveUserRolesQuery, IEnumerable<GetActiveUserRolesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;

        #endregion

        #region Constructor

        public GetActiveUserRolesQueryHandler(
            IMapper mapper,
            IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveUserRolesQueryResult>> Handle(
            GetActiveUserRolesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all user-role assignments that are currently active
                var userRoles = await _userRoleRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveUserRolesQueryResult>>(userRoles);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active user-role assignments: {ex.Message}");
            }
        }

        #endregion
    }
}
