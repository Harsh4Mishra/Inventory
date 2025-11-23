using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRulesQuery
{
    public class GetMaterialStorageRulesQueryHandler : IRequestHandler<GetMaterialStorageRulesQuery, IEnumerable<GetMaterialStorageRulesQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialStorageRuleRepository _materialStorageRuleRepository;

        #endregion

        #region Constructor

        public GetMaterialStorageRulesQueryHandler(
            IMapper mapper,
            IMaterialStorageRuleRepository materialStorageRuleRepository)
        {
            _mapper = mapper;
            _materialStorageRuleRepository = materialStorageRuleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetMaterialStorageRulesQueryResult>> Handle(
            GetMaterialStorageRulesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load all material storage rules
                var rules = await _materialStorageRuleRepository.GetAllAsync(cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetMaterialStorageRulesQueryResult>>(rules);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve material storage rules: {ex.Message}");
            }
        }

        #endregion
    }
}
