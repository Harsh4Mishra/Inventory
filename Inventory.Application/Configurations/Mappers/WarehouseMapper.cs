using AutoMapper;
using Inventory.Application.Features.Warehouse.Command.CreateWarehouseCommand;
using Inventory.Application.Features.Warehouse.Command.DeleteWarehouseCommand;
using Inventory.Application.Features.Warehouse.Command.ToggleWarehouseStatusCommand;
using Inventory.Application.Features.Warehouse.Command.UpdateWarehouseCommand;
using Inventory.Application.Features.Warehouse.Queries.GetActiveWarehousesQuery;
using Inventory.Application.Features.Warehouse.Queries.GetWarehouseByIdQuery;
using Inventory.Application.Features.Warehouse.Queries.GetWarehouseByNameQuery;
using Inventory.Application.Features.Warehouse.Queries.GetWarehousesQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class WarehouseMapper : Profile
    {
        public WarehouseMapper()
        {
            // Request Mappers
            CreateMap<CreateWarehouseCommand, WarehouseDO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<UpdateWarehouseCommand, WarehouseDO>()
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<DeleteWarehouseCommand, WarehouseDO>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<ToggleWarehouseStatusCommand, WarehouseDO>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            // Response Mappers
            CreateMap<WarehouseDO, GetWarehousesQueryResult>();
            CreateMap<WarehouseDO, GetActiveWarehousesQueryResult>();
            CreateMap<WarehouseDO, GetWarehouseByIdQueryResult>();
            CreateMap<WarehouseDO, GetWarehouseByNameQueryResult>();
        }
    }
}
