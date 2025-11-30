using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByProductQuery
{
    public sealed record GetInventoryTransactionsByProductQueryResult
    {
        #region Properties

        public long Id { get; init; }
        public Guid TransactionUUID { get; init; }
        public DateTime TransactionTime { get; init; }
        public string TransactionType { get; init; } = default!;
        public decimal Quantity { get; init; }
        public Guid? FromWarehouseId { get; init; }
        public Guid? ToWarehouseId { get; init; }
        public string? ReferenceType { get; init; }
        public Guid? ReferenceId { get; init; }
        public decimal? Cost { get; init; }
        public string? Notes { get; init; }
        public DateTime CreatedOn { get; init; }

        #endregion
    }
}
