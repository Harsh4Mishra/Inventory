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

        public Guid Id { get; init; }
        public Guid OrderId { get; init; }
        public Guid ProductId { get; init; }
        public Guid MaterialBatchId { get; init; }
        public decimal Quantity { get; init; }
        public DateTime CreatedOn { get; init; }

        #endregion
    }
}
