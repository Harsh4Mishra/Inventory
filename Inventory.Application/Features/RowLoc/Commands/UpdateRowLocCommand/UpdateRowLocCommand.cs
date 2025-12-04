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

        public int Id { get; init; } = default;
        public int AisleId { get; init; } = default;
        public string Name { get; init; } = default!;

        #endregion
    }
}
