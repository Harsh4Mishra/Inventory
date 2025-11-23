using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Queries.GetBomsQuery
{
    public class GetBomsQueryHandler : IRequestHandler<GetBomsQuery, IEnumerable<GetBomsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomRepository _bomRepository;

        #endregion

        #region Constructor

        public GetBomsQueryHandler(
            IMapper mapper,
            IBomRepository bomRepository)
        {
            _mapper = mapper;
            _bomRepository = bomRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetBomsQueryResult>> Handle(
            GetBomsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all BOMs
                var boms = await _bomRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetBomsQueryResult>>(boms);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOMs: {ex.Message}");
            }
        }

        #endregion
    }
}
