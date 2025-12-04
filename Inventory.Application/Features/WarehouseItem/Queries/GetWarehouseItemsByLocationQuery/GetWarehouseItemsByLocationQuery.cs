using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByLocationQuery
{
    public sealed record GetWarehouseItemsByLocationQuery : IRequest<IEnumerable<GetWarehouseItemsByLocationQueryResult>>
    {
        #region Properties
        public int WarehouseId { get; init; }
        public int AisleId { get; init; }
        public int RowId { get; init; }
        public int TrayId { get; init; }
        #endregion
    }
}
