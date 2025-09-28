using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.EnumValue.Queries.GetActiveEnumValuesByEnumTypeIdQuery
{
    public sealed class GetActiveEnumValuesByEnumTypeIdQueryHandler
        : IRequestHandler<GetActiveEnumValuesByEnumTypeIdQuery, IEnumerable<GetActiveEnumValuesByEnumTypeIdQueryResult>>
    {
        #region Fields

        private readonly IEnumValueRepository _enumValueRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public GetActiveEnumValuesByEnumTypeIdQueryHandler(
            IEnumValueRepository enumValueRepository,
            IMapper mapper)
        {
            _enumValueRepository = enumValueRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetActiveEnumValuesByEnumTypeIdQueryResult>> Handle(
            GetActiveEnumValuesByEnumTypeIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all active enum values by enum type id
                var result = await _enumValueRepository.GetAllActiveByEnumTypeIdAsync(request.EnumTypeId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveEnumValuesByEnumTypeIdQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve active enum values by enum type id: " + ex.Message);
            }
        }

        #endregion
    }
}
