using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionByUUIDQuery
{
    public sealed record GetInventoryTransactionByUUIDQuery : IRequest<GetInventoryTransactionByUUIDQueryResult?>
    {
        #region Properties
        public Guid UUID { get; init; }

        #endregion
    }
}
