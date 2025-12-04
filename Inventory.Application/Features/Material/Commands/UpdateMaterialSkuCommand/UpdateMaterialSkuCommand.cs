using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.UpdateMaterialSkuCommand
{
    public sealed record UpdateMaterialSkuCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; } = default;
        public string Sku { get; set; } = default!;
        #endregion
    }
}
