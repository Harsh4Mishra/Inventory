using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsByBomItemQuery
{
    public sealed record GetBomItemDispositionsByBomItemQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int BomItemId { get; init; }
        public string Disposition { get; init; } = default!;
        public string? Notes { get; init; }
        public DateTime ProcessedOn { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
