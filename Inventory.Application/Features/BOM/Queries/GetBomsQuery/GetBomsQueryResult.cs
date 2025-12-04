using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Queries.GetBomsQuery
{
    public sealed record GetBomsQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public bool IsApproved { get; init; }
        public int BomCategoryId { get; init; }
        public string? Result { get; init; }
        public decimal Quantity { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
