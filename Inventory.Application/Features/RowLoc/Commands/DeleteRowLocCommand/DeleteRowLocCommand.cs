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

        public Guid AisleId { get; init; }
        public Guid Id { get; init; }

        #endregion
    }
}
