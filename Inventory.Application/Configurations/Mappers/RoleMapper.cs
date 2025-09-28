using AutoMapper;
using Inventory.Application.Features.Role.Commands.CreateRoleCommand;
using Inventory.Application.Features.Role.Commands.DeleteRoleCommand;
using Inventory.Application.Features.Role.Commands.ToggleRoleStatusCommand;
using Inventory.Application.Features.Role.Commands.UpdateRoleCommand;
using Inventory.Application.Features.Role.Queries.GetActiveRolesQuery;
using Inventory.Application.Features.Role.Queries.GetRolesQuery;
using Inventory.Domain.DomainObjects;

namespace Inventory.Application.Configurations.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            // Request Mappers
            CreateMap<CreateRoleCommand, RoleDO>();
            CreateMap<UpdateRoleCommand, RoleDO>();
            CreateMap<DeleteRoleCommand, RoleDO>();
            CreateMap<ToggleRoleStatusCommand, RoleDO>();

            // Response Mappers
            CreateMap<RoleDO, GetRolesQueryResult>();
            CreateMap<RoleDO, GetActiveRolesQueryResult>();
        }
    }
}
