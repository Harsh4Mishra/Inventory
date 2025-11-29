using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetProductsQuery
{
    public sealed record GetProductsQuery : IRequest<IEnumerable<GetProductsQueryResult>>
    {
    }
}
