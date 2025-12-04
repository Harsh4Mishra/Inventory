using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Queries.GetTraysByRowIdQuery
{
    public sealed record GetTraysByRowIdQueryResult
    {
        #region Properties

        public int Id { get; init; } = default;
        public int RowId { get; init; } = default;
        public int Capacity { get; init; }
        public string? Description { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; } = default;
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
