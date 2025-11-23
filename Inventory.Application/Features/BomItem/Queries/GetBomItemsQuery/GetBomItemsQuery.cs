using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemsQuery
{
    public sealed record GetBomItemsQuery : IRequest<IEnumerable<GetBomItemsQueryResult>>
    {
    }
}
