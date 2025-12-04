using AutoMapper;
using Inventory.Application.Features.Allocation.Commands.CreateAllocationCommand;
using Inventory.Application.Features.Allocation.Commands.DeleteAllocationCommand;
using Inventory.Application.Features.Allocation.Commands.UpdateAllocationQuantityCommand;
using Inventory.Application.Features.Allocation.Commands.UpdateAllocationStatusCommand;
using Inventory.Application.Features.Allocation.Queries.GetActiveAllocationsQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationByIdQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsByMaterialBatchIdQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsByOrderIdQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsByProductIdQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsByStatusQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class AllocationMapper : Profile
    {
        public AllocationMapper()
        {
            // Request Mappers
            CreateMap<CreateAllocationCommand, AllocationDO>();
            CreateMap<UpdateAllocationStatusCommand, AllocationDO>();
            CreateMap<UpdateAllocationQuantityCommand, AllocationDO>();
            CreateMap<DeleteAllocationCommand, AllocationDO>();

            // Response Mappers
            CreateMap<AllocationDO, GetAllocationsQueryResult>();
            CreateMap<AllocationDO, GetActiveAllocationsQueryResult>();
            CreateMap<AllocationDO, GetAllocationsByOrderIdQueryResult>();
            CreateMap<AllocationDO, GetAllocationsByProductIdQueryResult>();
            CreateMap<AllocationDO, GetAllocationsByMaterialBatchIdQueryResult>();
            CreateMap<AllocationDO, GetAllocationsByStatusQueryResult>();
            CreateMap<AllocationDO, GetAllocationByIdQueryResult>();
        }
    }
}
