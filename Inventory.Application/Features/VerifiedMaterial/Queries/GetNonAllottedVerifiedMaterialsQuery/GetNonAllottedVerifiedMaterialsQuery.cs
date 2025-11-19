using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetNonAllottedVerifiedMaterialsQuery
{
    public sealed record GetNonAllottedVerifiedMaterialsQuery : IRequest<IEnumerable<GetNonAllottedVerifiedMaterialsQueryResult>>
    {
    }
}
