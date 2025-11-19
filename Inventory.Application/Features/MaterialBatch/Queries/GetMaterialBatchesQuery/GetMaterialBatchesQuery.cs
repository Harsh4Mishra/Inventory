using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesQuery
{
    public sealed record GetMaterialBatchesQuery : IRequest<IEnumerable<GetMaterialBatchesQueryResult>>
    {
    }
}
