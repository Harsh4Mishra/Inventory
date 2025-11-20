using AutoMapper;
using Inventory.Application.Features.StorageSection.Command.CreateStorageSectionCommand;
using Inventory.Application.Features.StorageSection.Command.DeleteStorageSectionCommand;
using Inventory.Application.Features.StorageSection.Command.ToggleStorageSectionStatusCommand;
using Inventory.Application.Features.StorageSection.Command.UpdateStorageSectionCommand;
using Inventory.Application.Features.StorageSection.Queries.GetActiveStorageSectionsQuery;
using Inventory.Application.Features.StorageSection.Queries.GetStorageSectionByIdQuery;
using Inventory.Application.Features.StorageSection.Queries.GetStorageSectionByNameQuery;
using Inventory.Application.Features.StorageSection.Queries.GetStorageSectionsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class StorageSectionMapper : Profile
    {
        public StorageSectionMapper()
        {
            // Request Mappers
            CreateMap<CreateStorageSectionCommand, StorageSectionDO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<UpdateStorageSectionCommand, StorageSectionDO>()
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<DeleteStorageSectionCommand, StorageSectionDO>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.TemperatureRange, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<ToggleStorageSectionStatusCommand, StorageSectionDO>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.TemperatureRange, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            // Response Mappers
            CreateMap<StorageSectionDO, GetStorageSectionsQueryResult>();
            CreateMap<StorageSectionDO, GetActiveStorageSectionsQueryResult>();
            CreateMap<StorageSectionDO, GetStorageSectionByIdQueryResult>();
            CreateMap<StorageSectionDO, GetStorageSectionByNameQueryResult>();
        }
    }
}
