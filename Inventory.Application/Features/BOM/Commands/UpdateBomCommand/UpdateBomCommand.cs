using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.UpdateBomCommand
{
    public sealed record UpdateBomCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public int BomCategoryId { get; set; }
        public string? Result { get; set; }
        public decimal Quantity { get; set; }
        #endregion
    }
}
