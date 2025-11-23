using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByIdQuery
{
    public sealed record GetMaterialStorageRuleByIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public Guid MaterialId { get; init; }
        public decimal MinQuantity { get; init; }
        public decimal ThresholdQuantity { get; init; }
        public Guid PreferredSectionId { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
