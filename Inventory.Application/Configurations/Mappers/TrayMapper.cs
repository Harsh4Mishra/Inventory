using AutoMapper;
using Inventory.Application.Features.Tray.Commands.CreateTrayCommand;
using Inventory.Application.Features.Tray.Commands.DeleteTrayCommand;
using Inventory.Application.Features.Tray.Commands.UpdateTrayCommand;
using Inventory.Application.Features.Tray.Queries.GetTrayByIdQuery;
using Inventory.Application.Features.Tray.Queries.GetTraysByRowIdQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class TrayMapper : Profile
    {
        public TrayMapper()
        {
            // Request Mapper(s)
            CreateMap<CreateTrayCommand, TrayDO>()
                .ForMember(dest => dest.RowId, opt => opt.MapFrom(src => src.RowLocId))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));

            CreateMap<UpdateTrayCommand, TrayDO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RowId, opt => opt.MapFrom(src => src.RowLocId))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));

            CreateMap<DeleteTrayCommand, TrayDO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RowId, opt => opt.MapFrom(src => src.RowLocId));

            // Response Mapper(s)
            CreateMap<TrayDO, GetTraysByRowIdQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RowId, opt => opt.MapFrom(src => src.RowId))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn));

            CreateMap<TrayDO, GetTrayByIdQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RowId, opt => opt.MapFrom(src => src.RowId))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn));
        }
    }
}
