using AutoMapper;
using Inventory.Application.Features.Permission.Commands.CreatePermissionCommand;
using Inventory.Application.Features.Permission.Commands.DeletePermissionCommand;
using Inventory.Application.Features.Permission.Commands.TogglePermissionCommand;
using Inventory.Application.Features.Permission.Commands.UpdatePermissionCommand;
using Inventory.Application.Features.Permission.Queries.GetActivePermissionsByTenantIdQuery;
using Inventory.Application.Features.Permission.Queries.GetPermissionByIdQuery;
using Inventory.Application.Features.Permission.Queries.GetPermissionsByTenantIdQuery;
using Inventory.Domain.DomainObjects;

namespace Inventory.Application.Configurations.Mappers
{
    public class PermissionMapper : Profile
    {
        public PermissionMapper()
        {
            // Request Mappers
            CreateMap<CreatePermissionCommand, PermissionDO>();
            CreateMap<UpdatePermissionCommand, PermissionDO>();
            CreateMap<DeletePermissionCommand, PermissionDO>();
            CreateMap<TogglePermissionCommand, PermissionDO>();

            // Response Mappers
            CreateMap<PermissionDO, GetPermissionsByTenantIdQueryResult>();
            CreateMap<PermissionDO, GetActivePermissionsByTenantIdQueryResult>();
            CreateMap<PermissionDO, GetPermissionByIdQueryResult>();
        }
    }
}
