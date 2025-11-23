using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Queries.GetPendingBomsQuery
{
    public class GetPendingBomsQueryHandler : IRequestHandler<GetPendingBomsQuery, IEnumerable<GetPendingBomsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomRepository _bomRepository;

        #endregion

        #region Constructor

        public GetPendingBomsQueryHandler(
            IMapper mapper,
            IBomRepository bomRepository)
        {
            _mapper = mapper;
            _bomRepository = bomRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetPendingBomsQueryResult>> Handle(
            GetPendingBomsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all pending BOMs
                var boms = await _bomRepository.GetAllPendingAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetPendingBomsQueryResult>>(boms);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve pending BOMs: {ex.Message}");
            }
        }

        #endregion
    }
}
