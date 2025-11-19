using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.UpdateQuantityCommand
{
    public sealed record UpdateQuantityCommand : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; init; }
        public decimal Quantity { get; init; }

        #endregion
    }
}
