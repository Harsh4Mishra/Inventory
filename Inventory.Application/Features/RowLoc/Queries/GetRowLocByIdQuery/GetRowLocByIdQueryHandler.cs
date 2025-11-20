using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Queries.GetRowLocByIdQuery
{
    public sealed class GetRowLocByIdQueryHandler
        : IRequestHandler<GetRowLocByIdQuery, GetRowLocByIdQueryResult>
    {
        #region Fields

        private readonly IRowLocRepository _rowLocRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public GetRowLocByIdQueryHandler(
            IRowLocRepository rowLocRepository,
            IMapper mapper)
        {
            _rowLocRepository = rowLocRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<GetRowLocByIdQueryResult> Handle(
            GetRowLocByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load row location by id
                var rowLoc = await _rowLocRepository.GetByIdAsync(request.Id, cancellationToken) ??
                    throw new InvalidOperationException($"No row location found with Id '{request.Id}'.");

                // 2. Project to the query result and return
                return _mapper.Map<GetRowLocByIdQueryResult>(rowLoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve row location by id " + ex.Message);
            }
        }

        #endregion
    }
}
