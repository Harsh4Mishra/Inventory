using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchByBatchCodeQuery
{
    public sealed record GetMaterialBatchByBatchCodeQuery : IRequest<GetMaterialBatchByBatchCodeQueryResult>
    {
        #region Properties
        public string BatchCode { get; init; } = default!;
        #endregion
    }
}
