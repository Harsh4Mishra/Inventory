using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemsQuery
{
    public class GetBomItemsQueryHandler : IRequestHandler<GetBomItemsQuery, IEnumerable<GetBomItemsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomItemRepository _bomItemRepository;

        #endregion

        #region Constructor

        public GetBomItemsQueryHandler(
            IMapper mapper,
            IBomItemRepository bomItemRepository)
        {
            _mapper = mapper;
            _bomItemRepository = bomItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetBomItemsQueryResult>> Handle(
            GetBomItemsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all BOM items
                var bomItems = await _bomItemRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetBomItemsQueryResult>>(bomItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM items: {ex.Message}");
            }
        }

        #endregion
    }
}
