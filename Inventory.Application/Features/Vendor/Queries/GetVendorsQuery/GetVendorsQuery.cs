using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Queries.GetVendorsQuery
{
    public sealed record GetVendorsQuery : IRequest<IEnumerable<GetVendorsQueryResult>>
    {
    }
}
