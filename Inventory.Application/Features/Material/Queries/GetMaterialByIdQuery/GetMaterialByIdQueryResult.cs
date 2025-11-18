using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Queries.GetMaterialByIdQuery
{
    public sealed record GetMaterialByIdQueryResult
    {
        #region Properties

        public Guid Id { get; init; }
        public string Sku { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string? Category { get; init; }
        public string? Subcategory { get; init; }
        public string? CasNumber { get; init; }
        public string? Description { get; init; }
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
