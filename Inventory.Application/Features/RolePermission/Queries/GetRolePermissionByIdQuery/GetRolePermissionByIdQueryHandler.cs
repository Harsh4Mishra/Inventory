using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.RolePermission.Queries.GetRolePermissionByIdQuery
{
    public class GetRolePermissionByIdQueryHandler : IRequestHandler<GetRolePermissionByIdQuery, GetRolePermissionByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        #endregion

        #region Constructor

        public GetRolePermissionByIdQueryHandler(
            IMapper mapper,
            IRolePermissionRepository rolePermissionRepository)
        {
            _mapper = mapper;
            _rolePermissionRepository = rolePermissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetRolePermissionByIdQueryResult?> Handle(
            GetRolePermissionByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the role-permission assignment by ID
                var rolePermission = await _rolePermissionRepository.GetByIdAsync(request.Id, cancellationToken);

                if (rolePermission == null)
                    return null;

                //2. Project to the query result and return
                var result = _mapper.Map<GetRolePermissionByIdQueryResult>(rolePermission);

                //3. TODO: Populate RoleName, ModuleName, PermissionName from related entities
                // This would require additional repository calls or a join query

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve role-permission assignment with ID '{request.Id}': {ex.Message}");
            }
        }

        #endregion
    }
}
