using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.EnumType.Queries.GetActiveEnumTypesQuery
{
    public class GetActiveEnumTypesQueryHandler
        : IRequestHandler<GetActiveEnumTypesQuery, IEnumerable<GetActiveEnumTypesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _enumTypeRepository;

        #endregion

        #region Ctor

        public GetActiveEnumTypesQueryHandler(
            IMapper mapper,
            IEnumTypeRepository enumTypeRepository)
        {
            _mapper = mapper;
            _enumTypeRepository = enumTypeRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetActiveEnumTypesQueryResult>> Handle(
            GetActiveEnumTypesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all enum types that are currently active
                var result = await _enumTypeRepository.GetAllActiveAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveEnumTypesQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve active enum types: " + ex.Message);
            }
        }

        #endregion
    }
}
