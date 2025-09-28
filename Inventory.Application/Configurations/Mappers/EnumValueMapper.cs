using AutoMapper;
using Inventory.Application.Features.EnumValue.Commands.CreateEnumValueCommand;
using Inventory.Application.Features.EnumValue.Commands.DeleteEnumValueCommand;
using Inventory.Application.Features.EnumValue.Commands.ToggleEnumValueStatusCommand;
using Inventory.Application.Features.EnumValue.Commands.UpdateEnumValueCommand;
using Inventory.Application.Features.EnumValue.Queries.GetActiveEnumValuesByEnumTypeIdQuery;
using Inventory.Application.Features.EnumValue.Queries.GetEnumValuesByEnumTypeIdQuery;
using Inventory.Domain.DomainObjects;

namespace Inventory.Application.Configurations.Mappers
{
    public class EnumValueMapper : Profile
    {
        public EnumValueMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateEnumValueCommand, EnumValueDO>();
            CreateMap<UpdateEnumValueCommand, EnumValueDO>();
            CreateMap<DeleteEnumValueCommand, EnumValueDO>();
            CreateMap<ToggleEnumValueStatusCommand, EnumValueDO>();

            //Response Mapper(s)
            CreateMap<EnumValueDO, GetActiveEnumValuesByEnumTypeIdQuery>();
            CreateMap<EnumValueDO, GetEnumValuesByEnumTypeIdQuery>();
        }
    }
}
