using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.UpdateWarehouseItemLocationCommand
{
    public sealed record UpdateWarehouseItemLocationCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int AisleId { get; set; }
        public int RowId { get; set; }
        public int TrayId { get; set; }
        #endregion
    }
}
