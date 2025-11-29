using AutoMapper;
using Inventory.Application.Features.BomItemDisposition.Commands.CreateBomItemDispositionCommand;
using Inventory.Application.Features.BomItemDisposition.Commands.DeleteBomItemDispositionCommand;
using Inventory.Application.Features.BomItemDisposition.Commands.UpdateBomItemDispositionCommand;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionByIdQuery;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsByBomItemQuery;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsByDispositionQuery;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class BomItemDispositionMapper : Profile
    {
        public BomItemDispositionMapper()
        {
            // Request Mappers
            CreateMap<CreateBomItemDispositionCommand, BomItemDispositionDO>();
            CreateMap<UpdateBomItemDispositionCommand, BomItemDispositionDO>();
            CreateMap<DeleteBomItemDispositionCommand, BomItemDispositionDO>();

            // Response Mappers
            CreateMap<BomItemDispositionDO, GetBomItemDispositionsQueryResult>();
            CreateMap<BomItemDispositionDO, GetBomItemDispositionsByBomItemQueryResult>();
            CreateMap<BomItemDispositionDO, GetBomItemDispositionsByDispositionQueryResult>();
            CreateMap<BomItemDispositionDO, GetBomItemDispositionsByIdQueryResult>();
        }
    }
}
