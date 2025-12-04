using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByMaterialIdQuery
{
    public sealed record GetMaterialStorageRuleByMaterialIdQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int MaterialId { get; init; }
        public decimal MinQuantity { get; init; }
        public decimal ThresholdQuantity { get; init; }
        public int PreferredSectionId { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
