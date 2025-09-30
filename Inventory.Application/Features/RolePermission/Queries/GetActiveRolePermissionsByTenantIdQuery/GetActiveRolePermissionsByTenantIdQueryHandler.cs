using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByTenantIdQuery
{
    public class GetActiveRolePermissionsByTenantIdQueryHandler : IRequestHandler<GetActiveRolePermissionsByTenantIdQuery, IEnumerable<GetActiveRolePermissionsByTenantIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        #endregion

        #region Constructor

        public GetActiveRolePermissionsByTenantIdQueryHandler(
            IMapper mapper,
            IRolePermissionRepository rolePermissionRepository)
        {
            _mapper = mapper;
            _rolePermissionRepository = rolePermissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveRolePermissionsByTenantIdQueryResult>> Handle(
            GetActiveRolePermissionsByTenantIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load active role-permission assignments by tenant ID
                var rolePermissions = await _rolePermissionRepository.GetActiveByTenantIdAsync(request.TenantId, cancellationToken);

                //2. Project to the query result and return
                var result = _mapper.Map<IEnumerable<GetActiveRolePermissionsByTenantIdQueryResult>>(rolePermissions);

                //3. TODO: Populate RoleName, ModuleName, PermissionName from related entities
                // This would require additional repository calls or a join query

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active role-permission assignments for tenant '{request.TenantId}': {ex.Message}");
            }
        }

        #endregion
    }
}
