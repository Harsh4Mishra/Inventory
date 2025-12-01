using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByMaterialBatchIdQuery
{
    public sealed record GetAllocationsByMaterialBatchIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid OrderId { get; init; }
        public Guid ProductId { get; init; }
        public decimal Quantity { get; init; }
        public string Status { get; init; } = default!;
        public DateTime CreatedOn { get; init; }

        #endregion
    }
}
