using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemsQuery
{
    public sealed record GetBomItemsQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid BomId { get; init; }
        public Guid MaterialBatchId { get; init; }
        public Guid WarehouseItemId { get; init; }
        public decimal Quantity { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
