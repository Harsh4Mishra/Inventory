using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsWithLowStockQuery
{
    public sealed record GetWarehouseItemsWithLowStockQuery : IRequest<IEnumerable<GetWarehouseItemsWithLowStockQueryResult>>
    {
        #region Properties
        public decimal Threshold { get; init; } = 10; // Default threshold
        #endregion
    }
}
