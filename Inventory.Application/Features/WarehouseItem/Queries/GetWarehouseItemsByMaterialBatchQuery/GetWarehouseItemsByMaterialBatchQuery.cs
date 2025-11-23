using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByMaterialBatchQuery
{
    public sealed record GetWarehouseItemsByMaterialBatchQuery : IRequest<IEnumerable<GetWarehouseItemsByMaterialBatchQueryResult>>
    {
        #region Properties
        public Guid MaterialBatchId { get; init; }
        #endregion
    }
}
