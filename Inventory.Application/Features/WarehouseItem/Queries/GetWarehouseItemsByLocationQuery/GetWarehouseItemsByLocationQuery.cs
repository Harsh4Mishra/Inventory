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
        public Guid WarehouseId { get; init; }
        public Guid AisleId { get; init; }
        public Guid RowId { get; init; }
        public Guid TrayId { get; init; }
        #endregion
    }
}
