using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemsByBomIdQuery
{
    public sealed record GetBomItemsByBomIdQuery : IRequest<IEnumerable<GetBomItemsByBomIdQueryResult>>
    {
        #region Properties
        public int BomId { get; init; }
        #endregion
    }
}
