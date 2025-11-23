using AutoMapper;
using Inventory.Application.Features.BomCategory.Commands.CreateBomCategoryCommand;
using Inventory.Application.Features.BomCategory.Commands.DeleteBomCategoryCommand;
using Inventory.Application.Features.BomCategory.Commands.UpdateBomCategoryCommand;
using Inventory.Application.Features.BomCategory.Queries.GetBomCategoriesQuery;
using Inventory.Application.Features.BomCategory.Queries.GetBomCategoryByIdQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class BomCategoryMapper : Profile
    {
        public BomCategoryMapper()
        {
            // Request Mappers
            CreateMap<CreateBomCategoryCommand, BomCategoryDO>();
            CreateMap<UpdateBomCategoryCommand, BomCategoryDO>();
            CreateMap<DeleteBomCategoryCommand, BomCategoryDO>();

            // Response Mappers
            CreateMap<BomCategoryDO, GetBomCategoriesQueryResult>();
            CreateMap<BomCategoryDO, GetBomCategoryByIdQueryResult>();
        }
    }
}
