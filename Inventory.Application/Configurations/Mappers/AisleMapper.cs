using AutoMapper;
using Inventory.Application.Features.Aisle.Commands.CreateAisleCommand;
using Inventory.Application.Features.Aisle.Commands.DeleteAisleCommand;
using Inventory.Application.Features.Aisle.Commands.UpdateAisleCommand;
using Inventory.Application.Features.Aisle.Queries.GetAislesByWarehouseIdQuery;
using Inventory.Application.Features.Aisle.Queries.GetAislesQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class AisleMapper : Profile
    {
        public AisleMapper()
        {
            // Request Mapper(s)
            CreateMap<CreateAisleCommand, AisleDO>()
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId))
                .ForMember(dest => dest.StorageSectionId, opt => opt.MapFrom(src => src.StorageSectionId))
                .ForMember(dest => dest.StorageTypeId, opt => opt.MapFrom(src => src.StorageTypeId))
                .ForMember(dest => dest.InventoryTypeId, opt => opt.MapFrom(src => src.InventoryTypeId));

            CreateMap<UpdateAisleCommand, AisleDO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StorageSectionId, opt => opt.MapFrom(src => src.StorageSectionId))
                .ForMember(dest => dest.StorageTypeId, opt => opt.MapFrom(src => src.StorageTypeId))
                .ForMember(dest => dest.InventoryTypeId, opt => opt.MapFrom(src => src.InventoryTypeId));

            CreateMap<DeleteAisleCommand, AisleDO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // Response Mapper(s)
            CreateMap<AisleDO, GetAislesQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId))
                .ForMember(dest => dest.StorageSectionId, opt => opt.MapFrom(src => src.StorageSectionId))
                .ForMember(dest => dest.StorageTypeId, opt => opt.MapFrom(src => src.StorageTypeId))
                .ForMember(dest => dest.InventoryTypeId, opt => opt.MapFrom(src => src.InventoryTypeId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn));

            CreateMap<AisleDO, GetAislesByWarehouseIdQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId))
                .ForMember(dest => dest.StorageSectionId, opt => opt.MapFrom(src => src.StorageSectionId))
                .ForMember(dest => dest.StorageTypeId, opt => opt.MapFrom(src => src.StorageTypeId))
                .ForMember(dest => dest.InventoryTypeId, opt => opt.MapFrom(src => src.InventoryTypeId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn));
        }
    }
}
