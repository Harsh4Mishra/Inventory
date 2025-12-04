using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetStockLevelQuery
{
    public sealed record GetStockLevelQuery : IRequest<decimal>
    {
        #region Properties
        public int? MaterialBatchId { get; init; }
        public int? ProductId { get; init; }

        #endregion
    }
}
