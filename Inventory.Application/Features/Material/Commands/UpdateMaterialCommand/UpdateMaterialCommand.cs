using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.UpdateMaterialCommand
{
    public sealed record UpdateMaterialCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public string? Category { get; set; }
        public string? Subcategory { get; set; }
        public string? CasNumber { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}
