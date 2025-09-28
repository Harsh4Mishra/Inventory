using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.EnumValue.Queries.GetEnumValuesByEnumTypeIdQuery
{
    public sealed class GetEnumValuesByEnumTypeIdQueryHandler
        : IRequestHandler<GetEnumValuesByEnumTypeIdQuery, IEnumerable<GetEnumValuesByEnumTypeIdQueryResult>>
    {
        #region Fields

        private readonly IEnumValueRepository _enumValueRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public GetEnumValuesByEnumTypeIdQueryHandler(
            IEnumValueRepository enumValueRepository,
            IMapper mapper)
        {
            _enumValueRepository = enumValueRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetEnumValuesByEnumTypeIdQueryResult>> Handle(
            GetEnumValuesByEnumTypeIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all enum values by enum type id
                var result = await _enumValueRepository.GetAllByEnumTypeIdAsync(request.EnumTypeId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetEnumValuesByEnumTypeIdQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve enum values by enum type id: " + ex.Message);
            }
        }

        #endregion
    }
}
