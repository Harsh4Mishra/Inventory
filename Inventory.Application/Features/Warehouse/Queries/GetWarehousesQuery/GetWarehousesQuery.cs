using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Queries.GetWarehousesQuery
{
    public sealed record GetWarehousesQuery : IRequest<IEnumerable<GetWarehousesQueryResult>>
    {
    }
}
