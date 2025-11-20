using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Commands.UpdateRowLocCommand
{
    public sealed record UpdateRowLocCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; init; } = default;
        public Guid AisleId { get; init; } = default;
        public string Name { get; init; } = default!;

        #endregion
    }
}
