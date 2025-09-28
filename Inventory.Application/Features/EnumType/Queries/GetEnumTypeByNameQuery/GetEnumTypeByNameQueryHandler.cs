using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.EnumType.Queries.GetEnumTypeByNameQuery
{
    public class GetEnumTypeByNameQueryHandler
        : IRequestHandler<GetEnumTypeByNameQuery, GetEnumTypeByNameQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _enumTypeRepository;

        #endregion

        #region Ctor

        public GetEnumTypeByNameQueryHandler(
            IMapper mapper,
            IEnumTypeRepository enumTypeRepository)
        {
            _mapper = mapper;
            _enumTypeRepository = enumTypeRepository;
        }

        #endregion

        #region Methods

        public async Task<GetEnumTypeByNameQueryResult> Handle(
            GetEnumTypeByNameQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load enum type by name
                var enumType = await _enumTypeRepository.GetByNameAsync(request.Name, cancellationToken);

                // 2. Return null if not found
                if (enumType == null)
                {
                    return null;
                }

                // 3. Map to the query result and return
                return _mapper.Map<GetEnumTypeByNameQueryResult>(enumType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve enum type by name '{request.Name}': {ex.Message}");
            }
        }

        #endregion
    }
}
