using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByTypeQuery
{
    public sealed record GetInventoryTransactionsByTypeQueryResult
    {
        #region Properties

        public long Id { get; init; }
        public string TransactionUUID { get; init; }
        public DateTime TransactionTime { get; init; }
        public decimal Quantity { get; init; }
        public int? MaterialBatchId { get; init; }
        public int? ProductId { get; init; }
        public int? FromWarehouseId { get; init; }
        public int? ToWarehouseId { get; init; }
        public string? ReferenceType { get; init; }
        public int? ReferenceId { get; init; }
        public decimal? Cost { get; init; }
        public DateTime CreatedOn { get; init; }

        #endregion
    }
}
