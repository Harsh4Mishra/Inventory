using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Queries.GetApprovedBomsQuery
{
    public sealed record GetApprovedBomsQuery : IRequest<IEnumerable<GetApprovedBomsQueryResult>>
    {
    }
}
