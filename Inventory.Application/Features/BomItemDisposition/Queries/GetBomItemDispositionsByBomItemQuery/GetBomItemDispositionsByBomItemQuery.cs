using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsByBomItemQuery
{
    public sealed record GetBomItemDispositionsByBomItemQuery : IRequest<IEnumerable<GetBomItemDispositionsByBomItemQueryResult>>
    {
        public int BomItemId { get; init; }
    }
}
