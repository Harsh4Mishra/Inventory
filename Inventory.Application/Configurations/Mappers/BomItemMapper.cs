using AutoMapper;
using Inventory.Application.Features.BomItem.Commands.CreateBomItemCommand;
using Inventory.Application.Features.BomItem.Commands.DeleteBomItemCommand;
using Inventory.Application.Features.BomItem.Commands.UpdateBomItemQuantityCommand;
using Inventory.Application.Features.BomItem.Queries.GetBomItemByIdQuery;
using Inventory.Application.Features.BomItem.Queries.GetBomItemsByBomIdQuery;
using Inventory.Application.Features.BomItem.Queries.GetBomItemsByMaterialBatchQuery;
using Inventory.Application.Features.BomItem.Queries.GetBomItemsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class BomItemMapper : Profile
    {
        public BomItemMapper()
        {
            // Request Mappers
            CreateMap<CreateBomItemCommand, BomItemDO>();
            CreateMap<DeleteBomItemCommand, BomItemDO>();
            CreateMap<UpdateBomItemQuantityCommand, BomItemDO>();

            // Response Mappers
            CreateMap<BomItemDO, GetBomItemsQueryResult>();
            CreateMap<BomItemDO, GetBomItemsByBomIdQueryResult>();
            CreateMap<BomItemDO, GetBomItemByIdQueryResult>();
            CreateMap<BomItemDO, GetBomItemsByMaterialBatchQueryResult>();
        }
    }
}
