using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Commands.CreateBomItemCommand
{
    public sealed record CreateBomItemCommand : IRequest<Guid>
    {
        #region Properties
        public Guid BomId { get; set; }
        public Guid MaterialBatchId { get; set; }
        public Guid WarehouseItemId { get; set; }
        public decimal Quantity { get; set; }
        #endregion
    }
}
