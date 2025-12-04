using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Commands.UpdateTrayCommand
{
    public sealed record UpdateTrayCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; init; } = default;
        public int AisleId { get; init; } = default;
        public int RowLocId { get; init; } = default;
        public int Capacity { get; init; }
        public string? Description { get; init; }

        #endregion
    }
}
