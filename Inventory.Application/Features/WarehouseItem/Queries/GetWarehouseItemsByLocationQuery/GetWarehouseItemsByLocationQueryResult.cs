using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByLocationQuery
{
    public sealed record GetWarehouseItemsByLocationQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid MaterialBatchId { get; init; }
        public Guid WarehouseId { get; init; }
        public Guid AisleId { get; init; }
        public Guid RowId { get; init; }
        public Guid TrayId { get; init; }
        public decimal Quantity { get; init; }
        public string Name { get; init; } = default!;
        public JsonDocument? Specification { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
