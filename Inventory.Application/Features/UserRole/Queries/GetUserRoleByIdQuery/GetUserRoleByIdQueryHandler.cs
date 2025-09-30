using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.UserRole.Queries.GetUserRoleByIdQuery
{
    public class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQuery, GetUserRoleByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;

        #endregion

        #region Constructor

        public GetUserRoleByIdQueryHandler(
            IMapper mapper,
            IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetUserRoleByIdQueryResult?> Handle(
            GetUserRoleByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the user-role assignment by ID
                var userRole = await _userRoleRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. Project to the query result and return (null if not found)
                return _mapper.Map<GetUserRoleByIdQueryResult?>(userRole);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve user-role assignment with ID '{request.Id}': {ex.Message}");
            }
        }

        #endregion
    }
}
