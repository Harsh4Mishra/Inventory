using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Commands.UpdateBomItemDispositionCommand
{
    public sealed record UpdateBomItemDispositionCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; } = default;
        public string Disposition { get; set; } = default!;
        public string? Notes { get; set; }

        #endregion
    }
}
