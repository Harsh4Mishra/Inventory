using AutoMapper;
using Inventory.Application.Features.WarehouseItem.Command.CreateWarehouseItemCommand;
using Inventory.Application.Features.WarehouseItem.Command.UpdateWarehouseItemLocationCommand;
using Inventory.Application.Features.WarehouseItem.Command.UpdateWarehouseItemQuantityCommand;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemByIdQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByLocationQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByMaterialBatchQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByWarehouseQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsWithLowStockQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class WarehouseItemMapper : Profile
    {
        public WarehouseItemMapper()
        {
            // Request Mappers
            CreateMap<CreateWarehouseItemCommand, WarehouseItemDO>();
            CreateMap<UpdateWarehouseItemQuantityCommand, WarehouseItemDO>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
            CreateMap<UpdateWarehouseItemLocationCommand, WarehouseItemDO>()
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId))
                .ForMember(dest => dest.AisleId, opt => opt.MapFrom(src => src.AisleId))
                .ForMember(dest => dest.RowId, opt => opt.MapFrom(src => src.RowId))
                .ForMember(dest => dest.TrayId, opt => opt.MapFrom(src => src.TrayId));

            // Response Mappers
            CreateMap<WarehouseItemDO, GetWarehouseItemsQueryResult>();
            CreateMap<WarehouseItemDO, GetWarehouseItemsByWarehouseQueryResult>();
            CreateMap<WarehouseItemDO, GetWarehouseItemsByMaterialBatchQueryResult>();
            CreateMap<WarehouseItemDO, GetWarehouseItemsByLocationQueryResult>();
            CreateMap<WarehouseItemDO, GetWarehouseItemByIdQueryResult>();
            CreateMap<WarehouseItemDO, GetWarehouseItemsWithLowStockQueryResult>();
        }
    }
}
