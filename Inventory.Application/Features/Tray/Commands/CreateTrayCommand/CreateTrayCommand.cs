using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Commands.CreateTrayCommand
{
    public sealed record CreateTrayCommand
        : IRequest<int>
    {
        #region Properties

        public int AisleId { get; init; }
        public int RowLocId { get; init; }
        public int Capacity { get; init; }
        public string? Description { get; init; }

        #endregion
    }
}
