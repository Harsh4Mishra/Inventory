using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetActiveProductsQuery
{
    public sealed record GetActiveProductsQuery : IRequest<IEnumerable<GetActiveProductsQueryResult>>
    {
    }
}
