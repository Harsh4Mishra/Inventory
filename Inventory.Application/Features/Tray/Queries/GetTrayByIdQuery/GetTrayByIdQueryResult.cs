using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Queries.GetTrayByIdQuery
{
    public sealed record GetTrayByIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; } = default;
        public Guid RowId { get; init; } = default;
        public int Capacity { get; init; }
        public string? Description { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; } = default;
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
