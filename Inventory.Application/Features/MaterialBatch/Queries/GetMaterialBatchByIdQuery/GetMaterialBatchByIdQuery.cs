using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchByIdQuery
{
    public sealed record GetMaterialBatchByIdQuery : IRequest<GetMaterialBatchByIdQueryResult>
    {
        #region Properties
        public int Id { get; init; }
        #endregion
    }
}
