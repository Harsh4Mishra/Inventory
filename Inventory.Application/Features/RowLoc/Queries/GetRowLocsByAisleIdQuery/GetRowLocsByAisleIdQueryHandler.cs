using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Queries.GetRowLocsByAisleIdQuery
{
    public sealed class GetRowLocsByAisleIdQueryHandler
        : IRequestHandler<GetRowLocsByAisleIdQuery, IEnumerable<GetRowLocsByAisleIdQueryResult>>
    {
        #region Fields

        private readonly IRowLocRepository _rowLocRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public GetRowLocsByAisleIdQueryHandler(
            IRowLocRepository rowLocRepository,
            IMapper mapper)
        {
            _rowLocRepository = rowLocRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetRowLocsByAisleIdQueryResult>> Handle(
            GetRowLocsByAisleIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all row locations by aisle id
                var result = await _rowLocRepository.GetAllByAisleIdAsync(request.AisleId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetRowLocsByAisleIdQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve row locations by aisle id " + ex.Message);
            }
        }

        #endregion
    }
}
