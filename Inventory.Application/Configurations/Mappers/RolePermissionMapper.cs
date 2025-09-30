using AutoMapper;
using Inventory.Application.Features.RolePermission.Commands.CreateRolePermissionCommand;
using Inventory.Application.Features.RolePermission.Commands.DeleteRolePermissionCommand;
using Inventory.Application.Features.RolePermission.Commands.ToggleRolePermissionCommand;
using Inventory.Application.Features.RolePermission.Commands.UpdateRolePermissionCommand;
using Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByPermissionIdQuery;
using Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByRoleIdQuery;
using Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByTenantIdQuery;
using Inventory.Application.Features.RolePermission.Queries.GetAllActiveRolePermissionsQuery;
using Inventory.Application.Features.RolePermission.Queries.GetAllRolePermissionsQuery;
using Inventory.Application.Features.RolePermission.Queries.GetRolePermissionByIdQuery;
using Inventory.Domain.DomainObjects;

namespace Inventory.Application.Configurations.Mappers
{
    public class RolePermissionMapper : Profile
    {
        public RolePermissionMapper()
        {
            // Request Mappers
            CreateMap<CreateRolePermissionCommand, RolePermissionDO>();
            CreateMap<UpdateRolePermissionCommand, RolePermissionDO>();
            CreateMap<DeleteRolePermissionCommand, RolePermissionDO>();
            CreateMap<ToggleRolePermissionCommand, RolePermissionDO>();

            // Response Mappers
            CreateMap<RolePermissionDO, GetAllRolePermissionsQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.Ignore())
                .ForMember(dest => dest.ModuleName, opt => opt.Ignore())
                .ForMember(dest => dest.PermissionName, opt => opt.Ignore());

            CreateMap<RolePermissionDO, GetAllActiveRolePermissionsQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.Ignore())
                .ForMember(dest => dest.ModuleName, opt => opt.Ignore())
                .ForMember(dest => dest.PermissionName, opt => opt.Ignore());

            CreateMap<RolePermissionDO, GetActiveRolePermissionsByRoleIdQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.Ignore())
                .ForMember(dest => dest.ModuleName, opt => opt.Ignore())
                .ForMember(dest => dest.PermissionName, opt => opt.Ignore());

            CreateMap<RolePermissionDO, GetActiveRolePermissionsByPermissionIdQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.Ignore())
                .ForMember(dest => dest.ModuleName, opt => opt.Ignore())
                .ForMember(dest => dest.PermissionName, opt => opt.Ignore());

            CreateMap<RolePermissionDO, GetRolePermissionByIdQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.Ignore())
                .ForMember(dest => dest.ModuleName, opt => opt.Ignore())
                .ForMember(dest => dest.PermissionName, opt => opt.Ignore());

            // Add to RolePermissionMapper class
            CreateMap<RolePermissionDO, GetActiveRolePermissionsByTenantIdQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.Ignore())
                .ForMember(dest => dest.ModuleName, opt => opt.Ignore())
                .ForMember(dest => dest.PermissionName, opt => opt.Ignore())
                .ForMember(dest => dest.TenantId, opt => opt.Ignore()); // Will be populated from related entities
        }
    }
}
