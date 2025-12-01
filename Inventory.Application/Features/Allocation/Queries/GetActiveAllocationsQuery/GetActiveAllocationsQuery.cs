using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetActiveAllocationsQuery
{
    public sealed record GetActiveAllocationsQuery : IRequest<IEnumerable<GetActiveAllocationsQueryResult>>
    {
    }
}
