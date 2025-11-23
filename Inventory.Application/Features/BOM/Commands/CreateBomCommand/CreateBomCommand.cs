using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.CreateBomCommand
{
    public sealed record CreateBomCommand : IRequest<Guid>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public Guid BomCategoryId { get; set; }
        public string? Result { get; set; }
        public decimal Quantity { get; set; }
        #endregion
    }
}
