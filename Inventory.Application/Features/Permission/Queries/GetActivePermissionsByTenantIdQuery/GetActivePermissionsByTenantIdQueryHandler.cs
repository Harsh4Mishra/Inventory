using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Permission.Queries.GetActivePermissionsByTenantIdQuery
{
    public class GetActivePermissionsByTenantIdQueryHandler : IRequestHandler<GetActivePermissionsByTenantIdQuery, IEnumerable<GetActivePermissionsByTenantIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IPermissionRepository _permissionRepository;

        #endregion

        #region Constructor

        public GetActivePermissionsByTenantIdQueryHandler(
            IMapper mapper,
            IPermissionRepository permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActivePermissionsByTenantIdQueryResult>> Handle(
            GetActivePermissionsByTenantIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all active permissions for the specified tenant
                var permissions = await _permissionRepository.GetActiveByTenantIdAsync(request.TenantId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActivePermissionsByTenantIdQueryResult>>(permissions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active permissions for tenant '{request.TenantId}': {ex.Message}");
            }
        }

        #endregion
    }
}
