using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRulesByPreferredSectionQuery
{
    public class GetMaterialStorageRulesByPreferredSectionQueryHandler : IRequestHandler<GetMaterialStorageRulesByPreferredSectionQuery, IEnumerable<GetMaterialStorageRulesByPreferredSectionQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialStorageRuleRepository _materialStorageRuleRepository;

        #endregion

        #region Constructor

        public GetMaterialStorageRulesByPreferredSectionQueryHandler(
            IMapper mapper,
            IMaterialStorageRuleRepository materialStorageRuleRepository)
        {
            _mapper = mapper;
            _materialStorageRuleRepository = materialStorageRuleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetMaterialStorageRulesByPreferredSectionQueryResult>> Handle(
            GetMaterialStorageRulesByPreferredSectionQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load material storage rules by preferred section ID
                var rules = await _materialStorageRuleRepository.GetByPreferredSectionIdAsync(request.PreferredSectionId, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetMaterialStorageRulesByPreferredSectionQueryResult>>(rules);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve material storage rules for preferred section '{request.PreferredSectionId}': {ex.Message}");
            }
        }

        #endregion
    }
}
