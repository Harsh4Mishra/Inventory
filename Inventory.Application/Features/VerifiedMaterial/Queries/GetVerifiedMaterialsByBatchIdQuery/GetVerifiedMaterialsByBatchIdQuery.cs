using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsByBatchIdQuery
{
    public sealed record GetVerifiedMaterialsByBatchIdQuery : IRequest<IEnumerable<GetVerifiedMaterialsByBatchIdQueryResult>>
    {
        public int MaterialBatchId { get; init; }
    }
}
