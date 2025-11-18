using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Queries.GetMaterialsQuery
{
    public sealed record GetMaterialsQuery : IRequest<IEnumerable<GetMaterialsQueryResult>>
    {
    }
}
