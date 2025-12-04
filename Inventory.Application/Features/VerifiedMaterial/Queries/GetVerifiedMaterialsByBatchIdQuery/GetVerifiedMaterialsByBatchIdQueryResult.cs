using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsByBatchIdQuery
{
    public sealed record GetVerifiedMaterialsByBatchIdQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int MaterialBatchId { get; init; }
        public bool IsAllotted { get; init; }
        public decimal Quantity { get; init; }
        public int? EmpId { get; init; }
        public JsonDocument? Specification { get; init; }
        public bool? IsQualified { get; init; }
        public string? Reason { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
