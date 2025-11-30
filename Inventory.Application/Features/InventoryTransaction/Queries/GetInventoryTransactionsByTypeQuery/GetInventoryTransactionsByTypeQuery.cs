using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByTypeQuery
{
    public sealed record GetInventoryTransactionsByTypeQuery : IRequest<IEnumerable<GetInventoryTransactionsByTypeQueryResult>>
    {
        #region Properties
        public string TransactionType { get; init; } = default!;

        #endregion
    }
}
