using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.CreateInventoryTransactionCommand
{
    public sealed record CreateInventoryTransactionCommand : IRequest<Guid>
    {
        #region Properties
        public string TransactionType { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? MaterialBatchId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? FromWarehouseId { get; set; }
        public Guid? ToWarehouseId { get; set; }
        public Guid? FromAisleId { get; set; }
        public Guid? ToAisleId { get; set; }
        public Guid? FromRowId { get; set; }
        public Guid? ToRowId { get; set; }
        public Guid? FromTrayId { get; set; }
        public Guid? ToTrayId { get; set; }
        public string? ReferenceType { get; set; }
        public Guid? ReferenceId { get; set; }
        public decimal? Cost { get; set; }
        public string? Notes { get; set; }

        #endregion
    }
}
