using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetProductBySkuQuery
{
    public sealed record GetProductBySkuQuery : IRequest<GetProductBySkuQueryResult>
    {
        public string Sku { get; init; } = string.Empty;
    }
}
