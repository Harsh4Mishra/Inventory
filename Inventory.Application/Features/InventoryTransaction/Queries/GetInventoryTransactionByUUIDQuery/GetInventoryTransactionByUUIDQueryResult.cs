using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionByUUIDQuery
{
    public sealed record GetInventoryTransactionByUUIDQueryResult
    {
        #region Properties

        public long Id { get; init; }
        public string TransactionUUID { get; init; }
        public DateTime TransactionTime { get; init; }
        public string TransactionType { get; init; } = default!;
        public int? MaterialBatchId { get; init; }
        public int? ProductId { get; init; }
        public decimal Quantity { get; init; }
        public int? FromWarehouseId { get; init; }
        public int? ToWarehouseId { get; init; }
        public int? FromAisleId { get; init; }
        public int? ToAisleId { get; init; }
        public int? FromRowId { get; init; }
        public int? ToRowId { get; init; }
        public int? FromTrayId { get; init; }
        public int? ToTrayId { get; init; }
        public string? ReferenceType { get; init; }
        public int? ReferenceId { get; init; }
        public int CreatedBy { get; init; }
        public decimal? Cost { get; init; }
        public string? Notes { get; init; }
        public string CreatedByUser { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
