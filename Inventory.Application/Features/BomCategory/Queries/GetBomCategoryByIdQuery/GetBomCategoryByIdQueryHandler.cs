using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Queries.GetBomCategoryByIdQuery
{
    public class GetBomCategoryByIdQueryHandler : IRequestHandler<GetBomCategoryByIdQuery, GetBomCategoryByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomCategoryRepository _bomCategoryRepository;

        #endregion

        #region Constructor

        public GetBomCategoryByIdQueryHandler(
            IMapper mapper,
            IBomCategoryRepository bomCategoryRepository)
        {
            _mapper = mapper;
            _bomCategoryRepository = bomCategoryRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetBomCategoryByIdQueryResult?> Handle(
            GetBomCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load BOM category by ID
                var category = await _bomCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<GetBomCategoryByIdQueryResult?>(category);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM category: {ex.Message}");
            }
        }

        #endregion
    }
}
