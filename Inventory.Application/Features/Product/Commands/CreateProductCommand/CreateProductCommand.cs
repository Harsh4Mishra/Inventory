using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.CreateProductCommand
{
    public sealed record CreateProductCommand : IRequest<int>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public int BomId { get; set; }

        #endregion
    }
}
