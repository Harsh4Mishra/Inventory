using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Queries.GetApprovedBomsQuery
{
    public class GetApprovedBomsQueryHandler : IRequestHandler<GetApprovedBomsQuery, IEnumerable<GetApprovedBomsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomRepository _bomRepository;

        #endregion

        #region Constructor

        public GetApprovedBomsQueryHandler(
            IMapper mapper,
            IBomRepository bomRepository)
        {
            _mapper = mapper;
            _bomRepository = bomRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetApprovedBomsQueryResult>> Handle(
            GetApprovedBomsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all approved BOMs
                var boms = await _bomRepository.GetAllApprovedAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetApprovedBomsQueryResult>>(boms);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve approved BOMs: {ex.Message}");
            }
        }

        #endregion
    }
}
