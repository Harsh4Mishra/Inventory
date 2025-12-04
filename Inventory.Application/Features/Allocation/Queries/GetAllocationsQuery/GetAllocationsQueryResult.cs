using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsQuery
{
    public sealed record GetAllocationsQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int OrderId { get; init; }
        public int ProductId { get; init; }
        public int MaterialBatchId { get; init; }
        public decimal Quantity { get; init; }
        public string Status { get; init; } = default!;
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
