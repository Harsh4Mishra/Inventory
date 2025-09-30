using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.AppModule.Queries.GetAppModulesByTenantIdQuery
{
    public class GetAppModulesByTenantIdQueryHandler : IRequestHandler<GetAppModulesByTenantIdQuery, IEnumerable<GetAppModulesByTenantIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAppModuleRepository _appModuleRepository;

        #endregion

        #region Constructor

        public GetAppModulesByTenantIdQueryHandler(
            IMapper mapper,
            IAppModuleRepository appModuleRepository)
        {
            _mapper = mapper;
            _appModuleRepository = appModuleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetAppModulesByTenantIdQueryResult>> Handle(
            GetAppModulesByTenantIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all app modules for the specified tenant
                var appModules = await _appModuleRepository.GetByTenantIdAsync(request.TenantId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAppModulesByTenantIdQueryResult>>(appModules);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve app modules for tenant '{request.TenantId}': {ex.Message}");
            }
        }

        #endregion
    }
}
