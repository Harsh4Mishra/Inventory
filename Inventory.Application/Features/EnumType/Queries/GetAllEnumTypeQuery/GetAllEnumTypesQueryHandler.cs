using AutoMapper;
using Inventory.Application.Contracts;
using MediatR;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.EnumType.Queries.GetAllEnumTypeQuery
{
    public class GetAllEnumTypesQueryHandler : IRequestHandler<GetAllEnumTypesQuery, IEnumerable<GetAllEnumTypesQueryResult>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _enumTypeRepository;

        #endregion

        #region Ctor

        public GetAllEnumTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumTypeRepository EnumTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _enumTypeRepository = EnumTypeRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllEnumTypesQueryResult>> Handle(GetAllEnumTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {

                // 1. Load all enum types
                var result = await _enumTypeRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAllEnumTypesQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
