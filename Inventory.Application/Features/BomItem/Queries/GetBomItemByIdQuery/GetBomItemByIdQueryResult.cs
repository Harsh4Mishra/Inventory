using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Queries.GetBomItemByIdQuery
{
    public sealed record GetBomItemByIdQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int BomId { get; init; }
        public int MaterialBatchId { get; init; }
        public int WarehouseItemId { get; init; }
        public decimal Quantity { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
