using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetAllRolePermissionsQuery
{
    public class GetAllRolePermissionsQueryHandler : IRequestHandler<GetAllRolePermissionsQuery, IEnumerable<GetAllRolePermissionsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        #endregion

        #region Constructor

        public GetAllRolePermissionsQueryHandler(
            IMapper mapper,
            IRolePermissionRepository rolePermissionRepository)
        {
            _mapper = mapper;
            _rolePermissionRepository = rolePermissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetAllRolePermissionsQueryResult>> Handle(
            GetAllRolePermissionsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all role-permission assignments
                var rolePermissions = await _rolePermissionRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                var result = _mapper.Map<IEnumerable<GetAllRolePermissionsQueryResult>>(rolePermissions);

                //3. TODO: Populate RoleName, ModuleName, PermissionName from related entities
                // This would require additional repository calls or a join query

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve all role-permission assignments: {ex.Message}");
            }
        }

        #endregion
    }
}
