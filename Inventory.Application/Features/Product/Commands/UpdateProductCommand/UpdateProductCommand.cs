using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Commands.UpdateProductCommand
{
    public sealed record UpdateProductCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public string Sku { get; set; } = default!;
        public Guid BomId { get; set; }

        #endregion
    }
}
