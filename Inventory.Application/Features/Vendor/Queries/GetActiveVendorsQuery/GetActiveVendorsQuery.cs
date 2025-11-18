using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Queries.GetActiveVendorsQuery
{
    public sealed record GetActiveVendorsQuery : IRequest<IEnumerable<GetActiveVendorsQueryResult>>
    {
    }
}
