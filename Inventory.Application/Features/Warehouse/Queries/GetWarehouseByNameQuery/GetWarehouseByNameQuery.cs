using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Queries.GetWarehouseByNameQuery
{
    public sealed record GetWarehouseByNameQuery : IRequest<GetWarehouseByNameQueryResult?>
    {
        public string Name { get; init; } = default!;
    }
}
