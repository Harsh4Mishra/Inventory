using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsQuery
{
    public sealed record GetAllocationsQuery : IRequest<IEnumerable<GetAllocationsQueryResult>>
    {
    }
}
