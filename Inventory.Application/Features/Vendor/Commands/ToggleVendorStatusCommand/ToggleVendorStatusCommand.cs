using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Commands.ToggleVendorStatusCommand
{
    public sealed record ToggleVendorStatusCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; init; }
        public bool IsActive { get; init; }
        #endregion
    }
}
