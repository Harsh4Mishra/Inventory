using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Queries.GetVendorByIdQuery
{
    public sealed record GetVendorByIdQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public string Type { get; init; } = default!;
        public string Contact { get; init; } = default!;
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
