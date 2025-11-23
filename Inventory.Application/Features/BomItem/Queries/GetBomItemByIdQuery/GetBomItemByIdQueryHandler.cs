using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemByIdQuery
{
    public class GetBomItemByIdQueryHandler : IRequestHandler<GetBomItemByIdQuery, GetBomItemByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomItemRepository _bomItemRepository;

        #endregion

        #region Constructor

        public GetBomItemByIdQueryHandler(
            IMapper mapper,
            IBomItemRepository bomItemRepository)
        {
            _mapper = mapper;
            _bomItemRepository = bomItemRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetBomItemByIdQueryResult?> Handle(
            GetBomItemByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load BOM item by ID
                var bomItem = await _bomItemRepository.GetByIdAsync(request.Id, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<GetBomItemByIdQueryResult?>(bomItem);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM item: {ex.Message}");
            }
        }

        #endregion
    }
}
