using AutoMapper;
using Inventory.Application.Features.BOM.Commands.ApproveBomCommand;
using Inventory.Application.Features.BOM.Commands.CreateBomCommand;
using Inventory.Application.Features.BOM.Commands.DeleteBomCommand;
using Inventory.Application.Features.BOM.Commands.RejectBomCommand;
using Inventory.Application.Features.BOM.Commands.UpdateBomCommand;
using Inventory.Application.Features.BOM.Queries.GetApprovedBomsQuery;
using Inventory.Application.Features.BOM.Queries.GetBomByIdQuery;
using Inventory.Application.Features.BOM.Queries.GetBomsQuery;
using Inventory.Application.Features.BOM.Queries.GetPendingBomsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class BomMapper : Profile
    {
        public BomMapper()
        {
            // Request Mappers
            CreateMap<CreateBomCommand, BomDO>();
            CreateMap<UpdateBomCommand, BomDO>();
            CreateMap<DeleteBomCommand, BomDO>();
            CreateMap<ApproveBomCommand, BomDO>();
            CreateMap<RejectBomCommand, BomDO>();

            // Response Mappers
            CreateMap<BomDO, GetBomsQueryResult>();
            CreateMap<BomDO, GetApprovedBomsQueryResult>();
            CreateMap<BomDO, GetPendingBomsQueryResult>();
            CreateMap<BomDO, GetBomByIdQueryResult>();
            //CreateMap<BomDO, GetBomsByCategoryQueryResult>();
        }
    }
}
