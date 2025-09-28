using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.EnumType.Queries.GetEnumTypeByIdQuery
{
    public class GetEnumTypeByIdQueryHandler
        : IRequestHandler<GetEnumTypeByIdQuery, GetEnumTypeByIdQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _enumTypeRepository;

        #endregion

        #region Ctor

        public GetEnumTypeByIdQueryHandler(
            IMapper mapper,
            IEnumTypeRepository enumTypeRepository)
        {
            _mapper = mapper;
            _enumTypeRepository = enumTypeRepository;
        }

        #endregion

        #region Methods

        public async Task<GetEnumTypeByIdQueryResult> Handle(
            GetEnumTypeByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load enum type by ID
                var enumType = await _enumTypeRepository.GetByIdAsync(request.Id, cancellationToken);

                // 2. Return null if not found
                if (enumType == null)
                {
                    return null;
                }

                // 3. Map to the query result and return
                return _mapper.Map<GetEnumTypeByIdQueryResult>(enumType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve enum type by ID '{request.Id}': {ex.Message}");
            }
        }

        #endregion
    }
}
