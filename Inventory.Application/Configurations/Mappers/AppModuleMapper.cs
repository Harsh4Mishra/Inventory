using AutoMapper;
using Inventory.Application.Features.AppModule.Commands.CreateAppModuleCommand;
using Inventory.Application.Features.AppModule.Commands.DeleteAppModuleCommand;
using Inventory.Application.Features.AppModule.Commands.ToggleAppModuleCommand;
using Inventory.Application.Features.AppModule.Commands.UpdateAppModuleCommand;
using Inventory.Application.Features.AppModule.Queries.GetActiveAppModulesByTenantIdQuery;
using Inventory.Application.Features.AppModule.Queries.GetAppModuleByIdQuery;
using Inventory.Application.Features.AppModule.Queries.GetAppModulesByTenantIdQuery;
using Inventory.Domain.DomainObjects;

namespace Inventory.Application.Configurations.Mappers
{
    public class AppModuleMapper : Profile
    {
        public AppModuleMapper()
        {
            // Request Mappers
            CreateMap<CreateAppModuleCommand, AppModuleDO>();
            CreateMap<UpdateAppModuleCommand, AppModuleDO>();
            CreateMap<DeleteAppModuleCommand, AppModuleDO>();
            CreateMap<ToggleAppModuleCommand, AppModuleDO>();

            // Response Mappers
            CreateMap<AppModuleDO, GetAppModulesByTenantIdQueryResult>();
            CreateMap<AppModuleDO, GetActiveAppModulesByTenantIdQueryResult>();
            CreateMap<AppModuleDO, GetAppModuleByIdQueryResult>();
        }
    }
}
