using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesQuery
{
    public sealed record GetMaterialBatchesQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public int MaterialId { get; init; }
        public int? VendorId { get; init; }
        public string BatchCode { get; init; } = default!;
        public string? Barcode { get; init; }
        public DateTime? ManufactureDate { get; init; }
        public DateTime? ExpiryDate { get; init; }
        public decimal Quantity { get; init; }
        public decimal RemainingQuantity { get; init; }
        public int? StorageSectionId { get; init; }
        public string? LocationText { get; init; }
        public bool IsActive { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        // Navigation properties
        public string? MaterialName { get; init; }
        public string? VendorName { get; init; }

        #endregion
    }
}
