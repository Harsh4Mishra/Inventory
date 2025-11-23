using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByMaterialIdQuery
{
    public class GetMaterialStorageRuleByMaterialIdQueryHandler : IRequestHandler<GetMaterialStorageRuleByMaterialIdQuery, GetMaterialStorageRuleByMaterialIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialStorageRuleRepository _materialStorageRuleRepository;

        #endregion

        #region Constructor

        public GetMaterialStorageRuleByMaterialIdQueryHandler(
            IMapper mapper,
            IMaterialStorageRuleRepository materialStorageRuleRepository)
        {
            _mapper = mapper;
            _materialStorageRuleRepository = materialStorageRuleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetMaterialStorageRuleByMaterialIdQueryResult?> Handle(
            GetMaterialStorageRuleByMaterialIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load material storage rules by material ID
                var rules = await _materialStorageRuleRepository.GetByMaterialIdAsync(request.MaterialId, cancellationToken);

                // 2. Return the first rule (since there should be only one per material)
                var rule = rules.FirstOrDefault();

                // 3. Project to the query result and return
                return _mapper.Map<GetMaterialStorageRuleByMaterialIdQueryResult?>(rule);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve material storage rule for material '{request.MaterialId}': {ex.Message}");
            }
        }

        #endregion
    }
}
