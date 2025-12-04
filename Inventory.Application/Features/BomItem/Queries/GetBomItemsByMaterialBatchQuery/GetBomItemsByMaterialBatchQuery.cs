using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemsByMaterialBatchQuery
{
    public sealed record GetBomItemsByMaterialBatchQuery : IRequest<IEnumerable<GetBomItemsByMaterialBatchQueryResult>>
    {
        #region Properties
        public int MaterialBatchId { get; init; }
        #endregion
    }
}
