using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByProductQuery
{
    public sealed record GetInventoryTransactionsByProductQuery : IRequest<IEnumerable<GetInventoryTransactionsByProductQueryResult>>
    {
        #region Properties
        public Guid ProductId { get; init; }

        #endregion
    }
}
