using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Queries.GetWarehouseByIdQuery
{
    public sealed record GetWarehouseByIdQuery : IRequest<GetWarehouseByIdQueryResult?>
    {
        public Guid Id { get; init; }
    }
}
