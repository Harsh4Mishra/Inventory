using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Product.Queries.GetProductByIdQuery
{
    public sealed record GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
    {
        public int Id { get; init; }
    }
}
