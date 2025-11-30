using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByDateRangeQuery
{
    public sealed record GetInventoryTransactionsByDateRangeQuery : IRequest<IEnumerable<GetInventoryTransactionsByDateRangeQueryResult>>
    {
        #region Properties
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        #endregion
    }
}
