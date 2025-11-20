using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Queries.GetTrayByIdQuery
{
    public sealed class GetTrayByIdQueryHandler
        : IRequestHandler<GetTrayByIdQuery, GetTrayByIdQueryResult>
    {
        #region Fields

        private readonly ITrayRepository _trayRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public GetTrayByIdQueryHandler(
            ITrayRepository trayRepository,
            IMapper mapper)
        {
            _trayRepository = trayRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<GetTrayByIdQueryResult> Handle(
            GetTrayByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load tray by id
                var tray = await _trayRepository.GetByIdAsync(request.Id, cancellationToken) ??
                    throw new InvalidOperationException($"No tray found with Id '{request.Id}'.");

                // 2. Project to the query result and return
                return _mapper.Map<GetTrayByIdQueryResult>(tray);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve tray by id " + ex.Message);
            }
        }

        #endregion
    }
}
