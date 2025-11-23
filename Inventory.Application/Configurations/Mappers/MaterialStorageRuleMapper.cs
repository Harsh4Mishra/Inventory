using AutoMapper;
using Inventory.Application.Features.MaterialStorageRule.Commands.CreateMaterialStorageRuleCommand;
using Inventory.Application.Features.MaterialStorageRule.Commands.DeleteMaterialStorageRuleCommand;
using Inventory.Application.Features.MaterialStorageRule.Commands.UpdateMaterialStorageRuleCommand;
using Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByIdQuery;
using Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByMaterialIdQuery;
using Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRulesByPreferredSectionQuery;
using Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRulesQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class MaterialStorageRuleMapper : Profile
    {
        public MaterialStorageRuleMapper()
        {
            // Request Mappers
            CreateMap<CreateMaterialStorageRuleCommand, MaterialStorageRuleDO>();
            CreateMap<UpdateMaterialStorageRuleCommand, MaterialStorageRuleDO>();
            CreateMap<DeleteMaterialStorageRuleCommand, MaterialStorageRuleDO>();

            // Response Mappers
            CreateMap<MaterialStorageRuleDO, GetMaterialStorageRulesQueryResult>();
            CreateMap<MaterialStorageRuleDO, GetMaterialStorageRuleByIdQueryResult>();
            CreateMap<MaterialStorageRuleDO, GetMaterialStorageRuleByMaterialIdQueryResult>();
            CreateMap<MaterialStorageRuleDO, GetMaterialStorageRulesByPreferredSectionQueryResult>();
        }
    }
}
