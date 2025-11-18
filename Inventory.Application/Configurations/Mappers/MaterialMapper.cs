using AutoMapper;
using Inventory.Application.Features.Material.Commands.CreateMaterialCommand;
using Inventory.Application.Features.Material.Commands.DeleteMaterialCommand;
using Inventory.Application.Features.Material.Commands.ToggleMaterialStatusCommand;
using Inventory.Application.Features.Material.Commands.UpdateMaterialCommand;
using Inventory.Application.Features.Material.Commands.UpdateMaterialSkuCommand;
using Inventory.Application.Features.Material.Queries.GetActiveMaterialsQuery;
using Inventory.Application.Features.Material.Queries.GetMaterialByIdQuery;
using Inventory.Application.Features.Material.Queries.GetMaterialBySkuQuery;
using Inventory.Application.Features.Material.Queries.GetMaterialsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class MaterialMapper : Profile
    {
        public MaterialMapper()
        {
            // Request Mappers
            CreateMap<CreateMaterialCommand, MaterialDO>();
            CreateMap<UpdateMaterialCommand, MaterialDO>();
            CreateMap<UpdateMaterialSkuCommand, MaterialDO>();
            CreateMap<DeleteMaterialCommand, MaterialDO>();
            CreateMap<ToggleMaterialStatusCommand, MaterialDO>();

            // Response Mappers
            CreateMap<MaterialDO, GetMaterialsQueryResult>();
            CreateMap<MaterialDO, GetActiveMaterialsQueryResult>();

            CreateMap<MaterialDO, GetMaterialByIdQueryResult>();
            CreateMap<MaterialDO, GetMaterialBySkuQueryResult>();

        }
    }
}
