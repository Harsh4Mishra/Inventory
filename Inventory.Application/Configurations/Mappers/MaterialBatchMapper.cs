using AutoMapper;
using Inventory.Application.Features.MaterialBatch.Queries.GetActiveMaterialBatchesQuery;
using Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchByBatchCodeQuery;
using Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchByIdQuery;
using Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesByMaterialIdQuery;
using Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class MaterialBatchMapper : Profile
    {
        public MaterialBatchMapper()
        {
            CreateMap<MaterialBatchDO, GetMaterialBatchesQueryResult>()
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material != null ? src.Material.Name : null))
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor != null ? src.Vendor.Name : null));

            CreateMap<MaterialBatchDO, GetActiveMaterialBatchesQueryResult>()
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material != null ? src.Material.Name : null))
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor != null ? src.Vendor.Name : null));

            CreateMap<MaterialBatchDO, GetMaterialBatchByIdQueryResult>()
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material != null ? src.Material.Name : null))
                .ForMember(dest => dest.MaterialSku, opt => opt.MapFrom(src => src.Material != null ? src.Material.Sku : null))
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor != null ? src.Vendor.Name : null));

            CreateMap<MaterialBatchDO, GetMaterialBatchByBatchCodeQueryResult>()
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material != null ? src.Material.Name : null))
                .ForMember(dest => dest.MaterialSku, opt => opt.MapFrom(src => src.Material != null ? src.Material.Sku : null))
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor != null ? src.Vendor.Name : null));

            CreateMap<MaterialBatchDO, GetMaterialBatchesByMaterialIdQueryResult>()
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor != null ? src.Vendor.Name : null));
        }
    }
}
