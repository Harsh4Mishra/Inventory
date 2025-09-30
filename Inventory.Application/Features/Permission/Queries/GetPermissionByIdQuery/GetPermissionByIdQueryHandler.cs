using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Permission.Queries.GetPermissionByIdQuery
{
    public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, GetPermissionByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IPermissionRepository _permissionRepository;

        #endregion

        #region Constructor

        public GetPermissionByIdQueryHandler(
            IMapper mapper,
            IPermissionRepository permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetPermissionByIdQueryResult?> Handle(
            GetPermissionByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the permission by ID
                var permission = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. Project to the query result and return (null if not found)
                return _mapper.Map<GetPermissionByIdQueryResult?>(permission);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve permission with ID '{request.Id}': {ex.Message}");
            }
        }

        #endregion
    }
}
