using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemsByBomIdQuery
{
    public class GetBomItemsByBomIdQueryHandler : IRequestHandler<GetBomItemsByBomIdQuery, IEnumerable<GetBomItemsByBomIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomItemRepository _bomItemRepository;

        #endregion

        #region Constructor

        public GetBomItemsByBomIdQueryHandler(
            IMapper mapper,
            IBomItemRepository bomItemRepository)
        {
            _mapper = mapper;
            _bomItemRepository = bomItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetBomItemsByBomIdQueryResult>> Handle(
            GetBomItemsByBomIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load BOM items by BOM ID
                var bomItems = await _bomItemRepository.GetByBomIdAsync(request.BomId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetBomItemsByBomIdQueryResult>>(bomItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM items for BOM '{request.BomId}': {ex.Message}");
            }
        }

        #endregion
    }
}
