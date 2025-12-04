using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.RemoveWarehouseItemQuantityCommand
{
    public sealed record RemoveWarehouseItemQuantityCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; }
        public decimal QuantityToRemove { get; set; }
        #endregion
    }
}
