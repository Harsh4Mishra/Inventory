using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesByMaterialIdQuery
{
    public sealed record GetMaterialBatchesByMaterialIdQuery : IRequest<IEnumerable<GetMaterialBatchesByMaterialIdQueryResult>>
    {
        #region Properties
        public int MaterialId { get; init; }
        #endregion
    }
}
