using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.AddWarehouseItemQuantityCommand
{
    public sealed record AddWarehouseItemQuantityCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; }
        public decimal QuantityToAdd { get; set; }
        #endregion
    }
}
