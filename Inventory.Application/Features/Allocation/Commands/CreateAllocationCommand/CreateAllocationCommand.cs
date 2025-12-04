using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.CreateAllocationCommand
{
    public sealed record CreateAllocationCommand : IRequest<int>
    {
        #region Properties
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int MaterialBatchId { get; set; }
        public decimal Quantity { get; set; }

        #endregion
    }
}
