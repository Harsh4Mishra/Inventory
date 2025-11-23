using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemsByMaterialBatchQuery
{
    public class GetBomItemsByMaterialBatchQueryHandler : IRequestHandler<GetBomItemsByMaterialBatchQuery, IEnumerable<GetBomItemsByMaterialBatchQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomItemRepository _bomItemRepository;

        #endregion

        #region Constructor

        public GetBomItemsByMaterialBatchQueryHandler(
            IMapper mapper,
            IBomItemRepository bomItemRepository)
        {
            _mapper = mapper;
            _bomItemRepository = bomItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetBomItemsByMaterialBatchQueryResult>> Handle(
            GetBomItemsByMaterialBatchQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load BOM items by material batch ID
                var bomItems = await _bomItemRepository.GetByMaterialBatchIdAsync(request.MaterialBatchId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetBomItemsByMaterialBatchQueryResult>>(bomItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM items for material batch '{request.MaterialBatchId}': {ex.Message}");
            }
        }

        #endregion
    }
}
