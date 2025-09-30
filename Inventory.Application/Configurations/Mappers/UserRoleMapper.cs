using AutoMapper;
using Inventory.Application.Features.UserRole.Commands.CreateUserRoleCommand;
using Inventory.Application.Features.UserRole.Commands.DeleteUserRoleCommand;
using Inventory.Application.Features.UserRole.Commands.ToggleUserRoleCommand;
using Inventory.Application.Features.UserRole.Commands.UpdateUserRoleCommand;
using Inventory.Application.Features.UserRole.Queries.GetActiveUserRolesQuery;
using Inventory.Application.Features.UserRole.Queries.GetUserRoleByIdQuery;
using Inventory.Application.Features.UserRole.Queries.GetUserRolesByRoleIdQuery;
using Inventory.Application.Features.UserRole.Queries.GetUserRolesByUserIdQuery;
using Inventory.Domain.DomainObjects;

namespace Inventory.Application.Configurations.Mappers
{
    public class UserRoleMapper : Profile
    {
        public UserRoleMapper()
        {
            // Request Mappers
            CreateMap<CreateUserRoleCommand, UserRoleDO>();

            CreateMap<UpdateUserRoleCommand, UserRoleDO>();

            CreateMap<DeleteUserRoleCommand, UserRoleDO>();

            CreateMap<ToggleUserRoleCommand, UserRoleDO>();

            // Response Mappers
            CreateMap<UserRoleDO, GetActiveUserRolesQueryResult>();

            CreateMap<UserRoleDO, GetUserRoleByIdQueryResult>();

            CreateMap<UserRoleDO, GetUserRolesByUserIdQueryResult>();

            CreateMap<UserRoleDO, GetUserRolesByRoleIdQueryResult>();
        }
    }
}
