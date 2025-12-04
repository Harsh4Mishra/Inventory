using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.CreateInventoryTransactionCommand
{
    public sealed record CreateInventoryTransactionCommand : IRequest<int>
    {
        #region Properties
        public string TransactionType { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public int CreatedBy { get; set; }
        public int? MaterialBatchId { get; set; }
        public int? ProductId { get; set; }
        public int? FromWarehouseId { get; set; }
        public int? ToWarehouseId { get; set; }
        public int? FromAisleId { get; set; }
        public int? ToAisleId { get; set; }
        public int? FromRowId { get; set; }
        public int? ToRowId { get; set; }
        public int? FromTrayId { get; set; }
        public int? ToTrayId { get; set; }
        public string? ReferenceType { get; set; }
        public int? ReferenceId { get; set; }
        public decimal? Cost { get; set; }
        public string? Notes { get; set; }

        #endregion
    }
}
