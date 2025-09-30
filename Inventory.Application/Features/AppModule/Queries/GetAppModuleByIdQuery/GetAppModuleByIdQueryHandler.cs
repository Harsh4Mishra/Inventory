using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.AppModule.Queries.GetAppModuleByIdQuery
{
    public class GetAppModuleByIdQueryHandler : IRequestHandler<GetAppModuleByIdQuery, GetAppModuleByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAppModuleRepository _appModuleRepository;

        #endregion

        #region Constructor

        public GetAppModuleByIdQueryHandler(
            IMapper mapper,
            IAppModuleRepository appModuleRepository)
        {
            _mapper = mapper;
            _appModuleRepository = appModuleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetAppModuleByIdQueryResult?> Handle(
            GetAppModuleByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the app module by ID
                var appModule = await _appModuleRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. Project to the query result and return (null if not found)
                return _mapper.Map<GetAppModuleByIdQueryResult?>(appModule);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve app module with ID '{request.Id}': {ex.Message}");
            }
        }

        #endregion
    }
}
