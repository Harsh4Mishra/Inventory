using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.ToggleAllotmentCommand
{
    public sealed record ToggleAllotmentCommand : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; init; }
        public bool IsAllotted { get; init; }

        #endregion
    }
}
