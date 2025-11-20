using AutoMapper;
using Inventory.Application.Features.RowLoc.Commands.CreateRowLocCommand;
using Inventory.Application.Features.RowLoc.Commands.DeleteRowLocCommand;
using Inventory.Application.Features.RowLoc.Commands.UpdateRowLocCommand;
using Inventory.Application.Features.RowLoc.Queries.GetRowLocByIdQuery;
using Inventory.Application.Features.RowLoc.Queries.GetRowLocsByAisleIdQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class RowLocMapper : Profile
    {
        public RowLocMapper()
        {
            // Request Mapper(s)
            CreateMap<CreateRowLocCommand, RowLocDO>()
                .ForMember(dest => dest.AisleId, opt => opt.MapFrom(src => src.AisleId));

            CreateMap<UpdateRowLocCommand, RowLocDO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AisleId, opt => opt.MapFrom(src => src.AisleId));

            CreateMap<DeleteRowLocCommand, RowLocDO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AisleId, opt => opt.MapFrom(src => src.AisleId));

            // Response Mapper(s)
            CreateMap<RowLocDO, GetRowLocsByAisleIdQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AisleId, opt => opt.MapFrom(src => src.AisleId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn));

            CreateMap<RowLocDO, GetRowLocByIdQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AisleId, opt => opt.MapFrom(src => src.AisleId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn));
        }
    }
}
