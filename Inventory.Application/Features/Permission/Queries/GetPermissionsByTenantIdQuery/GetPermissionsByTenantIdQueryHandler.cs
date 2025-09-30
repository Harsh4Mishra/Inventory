using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Permission.Queries.GetPermissionsByTenantIdQuery
{
    public class GetPermissionsByTenantIdQueryHandler : IRequestHandler<GetPermissionsByTenantIdQuery, IEnumerable<GetPermissionsByTenantIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IPermissionRepository _permissionRepository;

        #endregion

        #region Constructor

        public GetPermissionsByTenantIdQueryHandler(
            IMapper mapper,
            IPermissionRepository permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetPermissionsByTenantIdQueryResult>> Handle(
            GetPermissionsByTenantIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all permissions for the specified tenant
                var permissions = await _permissionRepository.GetByTenantIdAsync(request.TenantId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetPermissionsByTenantIdQueryResult>>(permissions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve permissions for tenant '{request.TenantId}': {ex.Message}");
            }
        }

        #endregion
    }
}
