using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.User.Queries.GetUsersQuery
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUsersQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructor

        public GetUsersQueryHandler(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetUsersQueryResult>> Handle(
            GetUsersQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all users from repository
                var users = await _userRepository.GetAllAsync(cancellationToken);

                // 2. Map to query result and return
                return _mapper.Map<IEnumerable<GetUsersQueryResult>>(users);
            }
            catch (Exception ex)
            {
                // TODO: Add proper error logging
                throw new Exception($"Failed to retrieve users: {ex.Message}");
            }
        }

        #endregion
    }
}
