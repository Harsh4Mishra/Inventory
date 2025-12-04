using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.CreateMaterialBatchCommand
{
    public sealed record CreateMaterialBatchCommand : IRequest<int>
    {
        #region Properties
        public int MaterialId { get; set; }
        public int? VendorId { get; set; }
        public string BatchCode { get; set; } = string.Empty;
        public string? Barcode { get; set; }
        public DateOnly? ManufactureDate { get; set; }
        public DateOnly? ExpiryDate { get; set; }
        public decimal Quantity { get; set; }
        public int? StorageSectionId { get; set; }
        public string? LocationText { get; set; }
        #endregion
    }
}
