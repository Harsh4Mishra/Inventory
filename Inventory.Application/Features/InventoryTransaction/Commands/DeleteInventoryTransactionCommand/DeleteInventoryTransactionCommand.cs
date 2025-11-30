using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.DeleteInventoryTransactionCommand
{
    public sealed record DeleteInventoryTransactionCommand : IRequest<Unit>
    {
        #region Properties
        public Guid Id { get; set; }

        #endregion
    }
}
