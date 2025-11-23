using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByIdQuery
{
    public class GetMaterialStorageRuleByIdQueryHandler : IRequestHandler<GetMaterialStorageRuleByIdQuery, GetMaterialStorageRuleByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialStorageRuleRepository _materialStorageRuleRepository;

        #endregion

        #region Constructor

        public GetMaterialStorageRuleByIdQueryHandler(
            IMapper mapper,
            IMaterialStorageRuleRepository materialStorageRuleRepository)
        {
            _mapper = mapper;
            _materialStorageRuleRepository = materialStorageRuleRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetMaterialStorageRuleByIdQueryResult?> Handle(
            GetMaterialStorageRuleByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load material storage rule by ID
                var rule = await _materialStorageRuleRepository.GetByIdAsync(request.Id, cancellationToken);

                // 2. Project to the query result and return
                return _mapper.Map<GetMaterialStorageRuleByIdQueryResult?>(rule);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve material storage rule: {ex.Message}");
            }
        }

        #endregion
    }
}
