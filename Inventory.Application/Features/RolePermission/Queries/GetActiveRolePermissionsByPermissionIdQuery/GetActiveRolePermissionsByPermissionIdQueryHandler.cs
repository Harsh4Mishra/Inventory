using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByPermissionIdQuery
{
    public class GetActiveRolePermissionsByPermissionIdQueryHandler : IRequestHandler<GetActiveRolePermissionsByPermissionIdQuery, IEnumerable<GetActiveRolePermissionsByPermissionIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        #endregion

        #region Constructor

        public GetActiveRolePermissionsByPermissionIdQueryHandler(
            IMapper mapper,
            IRolePermissionRepository rolePermissionRepository)
        {
            _mapper = mapper;
            _rolePermissionRepository = rolePermissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveRolePermissionsByPermissionIdQueryResult>> Handle(
            GetActiveRolePermissionsByPermissionIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load active role-permission assignments by permission ID
                var rolePermissions = await _rolePermissionRepository.GetActiveByPermissionIdAsync(request.PermissionId, cancellationToken);

                //2. Project to the query result and return
                var result = _mapper.Map<IEnumerable<GetActiveRolePermissionsByPermissionIdQueryResult>>(rolePermissions);

                //3. TODO: Populate RoleName, ModuleName, PermissionName from related entities
                // This would require additional repository calls or a join query

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active role-permission assignments for permission '{request.PermissionId}': {ex.Message}");
            }
        }

        #endregion
    }
}
