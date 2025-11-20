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

        public Guid Id { get; init; } = default;
        public Guid AisleId { get; init; } = default;
        public Guid RowLocId { get; init; } = default;
        public int Capacity { get; init; }
        public string? Description { get; init; }

        #endregion
    }
}
