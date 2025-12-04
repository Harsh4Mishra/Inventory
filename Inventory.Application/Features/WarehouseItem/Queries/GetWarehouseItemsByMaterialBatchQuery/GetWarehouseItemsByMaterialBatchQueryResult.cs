using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByMaterialBatchQuery
{
    public sealed record GetWarehouseItemsByMaterialBatchQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int MaterialBatchId { get; init; }
        public int WarehouseId { get; init; }
        public int AisleId { get; init; }
        public int RowId { get; init; }
        public int TrayId { get; init; }
        public decimal Quantity { get; init; }
        public string Name { get; init; } = default!;
        public string? Specification { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
