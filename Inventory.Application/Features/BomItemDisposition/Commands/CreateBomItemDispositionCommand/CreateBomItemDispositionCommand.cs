using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Commands.CreateBomItemDispositionCommand
{
    public sealed record CreateBomItemDispositionCommand : IRequest<Guid>
    {
        #region Properties
        public Guid BomItemId { get; set; }
        public string Disposition { get; set; } = string.Empty;
        public string? Notes { get; set; }

        #endregion
    }
}
