using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Queries.GetTraysByRowIdQuery
{
    public sealed class GetTraysByRowIdQueryHandler
        : IRequestHandler<GetTraysByRowIdQuery, IEnumerable<GetTraysByRowIdQueryResult>>
    {
        #region Fields

        private readonly ITrayRepository _trayRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public GetTraysByRowIdQueryHandler(
            ITrayRepository trayRepository,
            IMapper mapper)
        {
            _trayRepository = trayRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GetTraysByRowIdQueryResult>> Handle(
            GetTraysByRowIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all trays by row id
                var result = await _trayRepository.GetAllByRowIdAsync(request.RowId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetTraysByRowIdQueryResult>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve trays by row id " + ex.Message);
            }
        }

        #endregion
    }
}
