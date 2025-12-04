using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByMaterialBatchIdQuery
{
    public sealed record GetAllocationsByMaterialBatchIdQuery : IRequest<IEnumerable<GetAllocationsByMaterialBatchIdQueryResult>>
    {
        #region Properties
        public int MaterialBatchId { get; init; }

        #endregion
    }
}
