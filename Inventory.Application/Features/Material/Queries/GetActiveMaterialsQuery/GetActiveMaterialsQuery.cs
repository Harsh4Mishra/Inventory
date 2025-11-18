using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Queries.GetActiveMaterialsQuery
{
    public sealed record GetActiveMaterialsQuery : IRequest<IEnumerable<GetActiveMaterialsQueryResult>>
    {
    }
}
