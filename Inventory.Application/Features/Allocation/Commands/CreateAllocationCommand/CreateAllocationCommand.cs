using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.CreateAllocationCommand
{
    public sealed record CreateAllocationCommand : IRequest<Guid>
    {
        #region Properties
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid MaterialBatchId { get; set; }
        public decimal Quantity { get; set; }

        #endregion
    }
}
