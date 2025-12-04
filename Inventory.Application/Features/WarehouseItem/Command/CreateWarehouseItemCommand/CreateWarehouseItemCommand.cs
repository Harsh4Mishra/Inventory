using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.CreateWarehouseItemCommand
{
    public sealed record CreateWarehouseItemCommand : IRequest<int>
    {
        #region Properties
        public int MaterialBatchId { get; set; }
        public int WarehouseId { get; set; }
        public int AisleId { get; set; }
        public int RowId { get; set; }
        public int TrayId { get; set; }
        public decimal Quantity { get; set; }
        public string Name { get; set; } = string.Empty;
        public JsonDocument? Specification { get; set; }
        #endregion
    }
}
