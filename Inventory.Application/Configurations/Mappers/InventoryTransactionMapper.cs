using AutoMapper;
using Inventory.Application.Features.InventoryTransaction.Commands.CreateInventoryTransactionCommand;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionByUUIDQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByDateRangeQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByMaterialBatchQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByProductQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByTypeQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class InventoryTransactionMapper : Profile
    {
        public InventoryTransactionMapper()
        {
            // Request Mappers
            CreateMap<CreateInventoryTransactionCommand, InventoryTransactionDO>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy.ToString()));

            // Response Mappers
            CreateMap<InventoryTransactionDO, GetInventoryTransactionsQueryResult>()
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreatedBy.ToString()));

            CreateMap<InventoryTransactionDO, GetInventoryTransactionsByMaterialBatchQueryResult>();
            CreateMap<InventoryTransactionDO, GetInventoryTransactionsByProductQueryResult>();
            CreateMap<InventoryTransactionDO, GetInventoryTransactionsByDateRangeQueryResult>();
            CreateMap<InventoryTransactionDO, GetInventoryTransactionByUUIDQueryResult>()
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreatedBy.ToString()));
            CreateMap<InventoryTransactionDO, GetInventoryTransactionsByTypeQueryResult>();
        }
    }
}
