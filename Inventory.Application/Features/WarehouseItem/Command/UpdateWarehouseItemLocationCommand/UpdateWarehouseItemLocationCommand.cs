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
        public Guid Id { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid AisleId { get; set; }
        public Guid RowId { get; set; }
        public Guid TrayId { get; set; }
        #endregion
    }
}
