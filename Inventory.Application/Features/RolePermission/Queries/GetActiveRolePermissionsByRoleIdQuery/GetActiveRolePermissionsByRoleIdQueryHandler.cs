using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByRoleIdQuery
{
    public class GetActiveRolePermissionsByRoleIdQueryHandler : IRequestHandler<GetActiveRolePermissionsByRoleIdQuery, IEnumerable<GetActiveRolePermissionsByRoleIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        #endregion

        #region Constructor

        public GetActiveRolePermissionsByRoleIdQueryHandler(
            IMapper mapper,
            IRolePermissionRepository rolePermissionRepository)
        {
            _mapper = mapper;
            _rolePermissionRepository = rolePermissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveRolePermissionsByRoleIdQueryResult>> Handle(
            GetActiveRolePermissionsByRoleIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load active role-permission assignments by role ID
                var rolePermissions = await _rolePermissionRepository.GetActiveByRoleIdAsync(request.RoleId, cancellationToken);

                //2. Project to the query result and return
                var result = _mapper.Map<IEnumerable<GetActiveRolePermissionsByRoleIdQueryResult>>(rolePermissions);

                //3. TODO: Populate RoleName, ModuleName, PermissionName from related entities
                // This would require additional repository calls or a join query

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active role-permission assignments for role '{request.RoleId}': {ex.Message}");
            }
        }

        #endregion
    }
}
