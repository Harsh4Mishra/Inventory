using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.UserRole.Queries.GetUserRolesByRoleIdQuery
{
    public class GetUserRolesByRoleIdQueryHandler : IRequestHandler<GetUserRolesByRoleIdQuery, IEnumerable<GetUserRolesByRoleIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;

        #endregion

        #region Constructor

        public GetUserRolesByRoleIdQueryHandler(
            IMapper mapper,
            IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetUserRolesByRoleIdQueryResult>> Handle(
            GetUserRolesByRoleIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all user-role assignments for the specified role
                var userRoles = await _userRoleRepository.GetActiveByRoleIdAsync(request.RoleId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetUserRolesByRoleIdQueryResult>>(userRoles);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve user-role assignments for role '{request.RoleId}': {ex.Message}");
            }
        }

        #endregion
    }
}
