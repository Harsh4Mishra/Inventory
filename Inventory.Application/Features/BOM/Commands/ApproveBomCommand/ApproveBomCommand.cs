using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.ApproveBomCommand
{
    public sealed record ApproveBomCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; init; }
        #endregion
    }
}
