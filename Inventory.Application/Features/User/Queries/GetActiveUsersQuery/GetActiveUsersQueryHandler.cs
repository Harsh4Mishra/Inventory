using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.User.Queries.GetActiveUsersQuery
{
    public class GetActiveUsersQueryHandler : IRequestHandler<GetActiveUsersQuery, IEnumerable<GetActiveUsersQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructor

        public GetActiveUsersQueryHandler(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveUsersQueryResult>> Handle(
            GetActiveUsersQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load only active users from repository
                var users = await _userRepository.GetAllActiveAsync(cancellationToken);

                // 2. Map to query result and return
                return _mapper.Map<IEnumerable<GetActiveUsersQueryResult>>(users);
            }
            catch (Exception ex)
            {
                // TODO: Add proper error logging
                throw new Exception($"Failed to retrieve active users: {ex.Message}");
            }
        }

        #endregion
    }
}
