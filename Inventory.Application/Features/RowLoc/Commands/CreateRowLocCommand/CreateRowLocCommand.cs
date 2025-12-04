using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Commands.CreateRowLocCommand
{
    public sealed record CreateRowLocCommand
        : IRequest<int>
    {
        #region Properties

        public int AisleId { get; init; }
        public string Name { get; init; } = default!;

        #endregion
    }
}
