using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Queries.GetRowLocsByAisleIdQuery
{
    public sealed record GetRowLocsByAisleIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; } = default;
        public Guid AisleId { get; init; } = default;
        public string Name { get; init; } = default!;
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; } = default;
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
