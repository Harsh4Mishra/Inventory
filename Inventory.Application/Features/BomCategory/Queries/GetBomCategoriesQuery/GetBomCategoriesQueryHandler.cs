using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Queries.GetBomCategoriesQuery
{
    public class GetBomCategoriesQueryHandler : IRequestHandler<GetBomCategoriesQuery, IEnumerable<GetBomCategoriesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomCategoryRepository _bomCategoryRepository;

        #endregion

        #region Constructor

        public GetBomCategoriesQueryHandler(
            IMapper mapper,
            IBomCategoryRepository bomCategoryRepository)
        {
            _mapper = mapper;
            _bomCategoryRepository = bomCategoryRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetBomCategoriesQueryResult>> Handle(
            GetBomCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all BOM categories
                var categories = await _bomCategoryRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetBomCategoriesQueryResult>>(categories);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM categories: {ex.Message}");
            }
        }

        #endregion
    }
}
