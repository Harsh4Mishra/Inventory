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
        public Guid TransactionUUID { get; init; }
        public DateTime TransactionTime { get; init; }
        public string TransactionType { get; init; } = default!;
        public Guid? MaterialBatchId { get; init; }
        public Guid? ProductId { get; init; }
        public decimal Quantity { get; init; }
        public Guid? FromWarehouseId { get; init; }
        public Guid? ToWarehouseId { get; init; }
        public Guid? FromAisleId { get; init; }
        public Guid? ToAisleId { get; init; }
        public Guid? FromRowId { get; init; }
        public Guid? ToRowId { get; init; }
        public Guid? FromTrayId { get; init; }
        public Guid? ToTrayId { get; init; }
        public string? ReferenceType { get; init; }
        public Guid? ReferenceId { get; init; }
        public Guid CreatedBy { get; init; }
        public decimal? Cost { get; init; }
        public string? Notes { get; init; }
        public string CreatedByUser { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
