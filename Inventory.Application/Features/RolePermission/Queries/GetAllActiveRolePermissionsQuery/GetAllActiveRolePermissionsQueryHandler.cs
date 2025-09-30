using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetAllActiveRolePermissionsQuery
{
    public class GetAllActiveRolePermissionsQueryHandler : IRequestHandler<GetAllActiveRolePermissionsQuery, IEnumerable<GetAllActiveRolePermissionsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        #endregion

        #region Constructor

        public GetAllActiveRolePermissionsQueryHandler(
            IMapper mapper,
            IRolePermissionRepository rolePermissionRepository)
        {
            _mapper = mapper;
            _rolePermissionRepository = rolePermissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetAllActiveRolePermissionsQueryResult>> Handle(
            GetAllActiveRolePermissionsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all active role-permission assignments
                var rolePermissions = await _rolePermissionRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                var result = _mapper.Map<IEnumerable<GetAllActiveRolePermissionsQueryResult>>(rolePermissions);

                //3. TODO: Populate RoleName, ModuleName, PermissionName from related entities
                // This would require additional repository calls or a join query

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve all active role-permission assignments: {ex.Message}");
            }
        }

        #endregion
    }
}
