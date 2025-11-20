using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Queries.GetAislesQuery
{
    public sealed record GetAislesQuery
         : IRequest<IEnumerable<GetAislesQueryResult>>
    {
    }
}
