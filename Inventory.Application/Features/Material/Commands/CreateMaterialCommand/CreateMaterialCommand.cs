using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.CreateMaterialCommand
{
    public sealed record CreateMaterialCommand : IRequest<Guid>
    {
        #region Properties
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? Subcategory { get; set; }
        public string? CasNumber { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}
