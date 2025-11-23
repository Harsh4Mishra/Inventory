using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Queries.GetBomByIdQuery
{
    public class GetBomByIdQueryHandler : IRequestHandler<GetBomByIdQuery, GetBomByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomRepository _bomRepository;

        #endregion

        #region Constructor

        public GetBomByIdQueryHandler(
            IMapper mapper,
            IBomRepository bomRepository)
        {
            _mapper = mapper;
            _bomRepository = bomRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetBomByIdQueryResult?> Handle(
            GetBomByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load BOM by ID
                var bom = await _bomRepository.GetByIdAsync(request.Id, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<GetBomByIdQueryResult?>(bom);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM: {ex.Message}");
            }
        }

        #endregion
    }
}
