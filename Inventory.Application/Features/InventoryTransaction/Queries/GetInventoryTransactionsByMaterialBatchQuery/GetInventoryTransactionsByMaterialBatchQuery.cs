using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByMaterialBatchQuery
{
    public sealed record GetInventoryTransactionsByMaterialBatchQuery : IRequest<IEnumerable<GetInventoryTransactionsByMaterialBatchQueryResult>>
    {
        #region Properties
        public Guid MaterialBatchId { get; init; }

        #endregion
    }
}
