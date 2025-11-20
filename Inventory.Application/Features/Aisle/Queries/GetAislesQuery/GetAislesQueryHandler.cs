using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Queries.GetAislesQuery
{
    public class GetAislesQueryHandler
        : IRequestHandler<GetAislesQuery, IEnumerable<GetAislesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAisleRepository _aisleRepository;

        #endregion

        #region Ctor

        public GetAislesQueryHandler(
            IMapper mapper,
            IAisleRepository aisleRepository)
        {
            _mapper = mapper;
            _aisleRepository = aisleRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetAislesQueryResult>> Handle(
            GetAislesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all aisles
                var result = await _aisleRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetAislesQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve aisles " + ex.Message);
            }
        }

        #endregion
    }
}
