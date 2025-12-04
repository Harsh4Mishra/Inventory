using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.UpdateAllocationStatusCommand
{
    public sealed record UpdateAllocationStatusCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; }
        public string Status { get; set; } = default!; // "picked", "shipped", "released", "cancelled"

        #endregion
    }
}
