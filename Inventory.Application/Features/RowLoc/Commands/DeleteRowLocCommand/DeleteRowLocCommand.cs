using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Commands.DeleteRowLocCommand
{
    public sealed record DeleteRowLocCommand
        : IRequest<Unit>
    {
        #region Properties

        public int AisleId { get; init; }
        public int Id { get; init; }

        #endregion
    }
}
