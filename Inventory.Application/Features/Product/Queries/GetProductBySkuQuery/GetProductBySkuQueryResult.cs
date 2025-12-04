using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetProductBySkuQuery
{
    public sealed record GetProductBySkuQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public string Sku { get; init; } = default!;
        public int BomId { get; init; }
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
