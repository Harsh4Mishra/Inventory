using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Commands.CreateBomItemCommand
{
    public sealed record CreateBomItemCommand : IRequest<int>
    {
        #region Properties
        public int BomId { get; set; }
        public int MaterialBatchId { get; set; }
        public int WarehouseItemId { get; set; }
        public decimal Quantity { get; set; }
        #endregion
    }
}
