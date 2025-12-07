using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.UpdateMaterialBatchCommand
{
    public sealed record UpdateMaterialBatchCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; } = default;
        public int? VendorId { get; set; }
        public string? Barcode { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? StorageSectionId { get; set; }
        public string? LocationText { get; set; }
        #endregion
    }
}
