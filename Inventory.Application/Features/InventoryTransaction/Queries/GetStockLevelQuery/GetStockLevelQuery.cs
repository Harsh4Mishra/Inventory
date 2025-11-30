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
        public Guid? MaterialBatchId { get; init; }
        public Guid? ProductId { get; init; }

        #endregion
    }
}
