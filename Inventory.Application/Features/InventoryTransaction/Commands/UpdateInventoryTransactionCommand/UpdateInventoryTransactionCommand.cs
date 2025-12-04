using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.UpdateInventoryTransactionCommand
{
    public sealed record UpdateInventoryTransactionCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; }
        public decimal? Cost { get; set; }
        public string? Notes { get; set; }

        #endregion
    }
}
