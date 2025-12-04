using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByStatusQuery
{
    public sealed record GetAllocationsByStatusQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int OrderId { get; init; }
        public int ProductId { get; init; }
        public int MaterialBatchId { get; init; }
        public decimal Quantity { get; init; }
        public DateTime CreatedOn { get; init; }

        #endregion
    }
}
