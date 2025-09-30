using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.AppModule.Queries.GetActiveAppModulesByTenantIdQuery
{
    public class GetActiveAppModulesByTenantIdQueryHandler : IRequestHandler<GetActiveAppModulesByTenantIdQuery, IEnumerable<GetActiveAppModulesByTenantIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAppModuleRepository _appModuleRepository;

        #endregion

        #region Constructor

        public GetActiveAppModulesByTenantIdQueryHandler(
            IMapper mapper,
            IAppModuleRepository appModuleRepository)
        {
            _mapper = mapper;
            _appModuleRepository = appModuleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveAppModulesByTenantIdQueryResult>> Handle(
            GetActiveAppModulesByTenantIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all active app modules for the specified tenant
                var appModules = await _appModuleRepository.GetActiveByTenantIdAsync(request.TenantId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveAppModulesByTenantIdQueryResult>>(appModules);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active app modules for tenant '{request.TenantId}': {ex.Message}");
            }
        }

        #endregion
    }
}
