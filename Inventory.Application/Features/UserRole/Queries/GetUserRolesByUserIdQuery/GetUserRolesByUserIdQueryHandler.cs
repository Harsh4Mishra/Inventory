using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.UserRole.Queries.GetUserRolesByUserIdQuery
{
    public class GetUserRolesByUserIdQueryHandler : IRequestHandler<GetUserRolesByUserIdQuery, IEnumerable<GetUserRolesByUserIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;

        #endregion

        #region Constructor

        public GetUserRolesByUserIdQueryHandler(
            IMapper mapper,
            IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetUserRolesByUserIdQueryResult>> Handle(
            GetUserRolesByUserIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all user-role assignments for the specified user
                var userRoles = await _userRoleRepository.GetActiveByUserIdAsync(request.UserId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetUserRolesByUserIdQueryResult>>(userRoles);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve user-role assignments for user '{request.UserId}': {ex.Message}");
            }
        }

        #endregion
    }
}
