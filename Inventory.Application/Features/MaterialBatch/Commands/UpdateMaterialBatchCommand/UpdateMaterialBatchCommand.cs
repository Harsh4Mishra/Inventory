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
        public Guid Id { get; set; } = default;
        public Guid? VendorId { get; set; }
        public string? Barcode { get; set; }
        public DateOnly? ManufactureDate { get; set; }
        public DateOnly? ExpiryDate { get; set; }
        public Guid? StorageSectionId { get; set; }
        public string? LocationText { get; set; }
        #endregion
    }
}
