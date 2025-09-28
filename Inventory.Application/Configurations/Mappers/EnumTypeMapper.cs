using AutoMapper;
using Inventory.Application.Features.EnumType.Commands.CreateEnumTypeCommand;
using Inventory.Application.Features.EnumType.Commands.DeleteEnumTypeCommand;
using Inventory.Application.Features.EnumType.Commands.ToggleEnumTypeStatusCommand;
using Inventory.Application.Features.EnumType.Commands.UpdateEnumTypeCommand;
using Inventory.Application.Features.EnumType.Queries.GetActiveEnumTypesQuery;
using Inventory.Application.Features.EnumType.Queries.GetAllEnumTypeQuery;
using Inventory.Application.Features.EnumType.Queries.GetEnumTypeByIdQuery;
using Inventory.Application.Features.EnumType.Queries.GetEnumTypeByNameQuery;
using Inventory.Domain.DomainObjects;

namespace Inventory.Application.Configurations.Mappers
{
    public class EnumTypeMapper : Profile
    {
        public EnumTypeMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateEnumTypeCommand, EnumTypeDO>();
            CreateMap<UpdateEnumTypeCommand, EnumTypeDO>();
            CreateMap<DeleteEnumTypeCommand, EnumTypeDO>();
            CreateMap<ToggleEnumTypeStatusCommand, EnumTypeDO>();

            //Response Mapper(s)
            CreateMap<EnumTypeDO, GetActiveEnumTypesQueryResult>();
            CreateMap<EnumTypeDO, GetAllEnumTypesQueryResult>();
            CreateMap<EnumTypeDO, GetEnumTypeByIdQuery>();
            CreateMap<EnumTypeDO, GetEnumTypeByNameQuery>();
        }
    }
}
