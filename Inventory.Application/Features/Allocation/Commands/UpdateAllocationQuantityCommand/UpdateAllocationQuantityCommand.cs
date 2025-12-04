using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.UpdateAllocationQuantityCommand
{
    public sealed record UpdateAllocationQuantityCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; }
        public decimal Quantity { get; set; }

        #endregion
    }
}
