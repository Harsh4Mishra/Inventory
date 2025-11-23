using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.CreateWarehouseItemCommand
{
    public sealed record CreateWarehouseItemCommand : IRequest<Guid>
    {
        #region Properties
        public Guid MaterialBatchId { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid AisleId { get; set; }
        public Guid RowId { get; set; }
        public Guid TrayId { get; set; }
        public decimal Quantity { get; set; }
        public string Name { get; set; } = string.Empty;
        public JsonDocument? Specification { get; set; }
        #endregion
    }
}
