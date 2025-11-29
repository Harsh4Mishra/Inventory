using AutoMapper;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsQuery;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsByBomItemQuery
{
    public class GetBomItemDispositionsByBomItemQueryHandler : IRequestHandler<GetBomItemDispositionsByBomItemQuery, IEnumerable<GetBomItemDispositionsByBomItemQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomItemDispositionRepository _bomItemDispositionRepository;

        #endregion

        #region Constructor

        public GetBomItemDispositionsByBomItemQueryHandler(
            IMapper mapper,
            IBomItemDispositionRepository bomItemDispositionRepository)
        {
            _mapper = mapper;
            _bomItemDispositionRepository = bomItemDispositionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetBomItemDispositionsByBomItemQueryResult>> Handle(
            GetBomItemDispositionsByBomItemQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load dispositions by BOM item ID
                var dispositions = await _bomItemDispositionRepository.GetByBomItemIdAsync(request.BomItemId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetBomItemDispositionsByBomItemQueryResult>>(dispositions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM item dispositions by BOM item ID: {ex.Message}");
            }
        }

        #endregion
    }
}
