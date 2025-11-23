using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByWarehouseQuery
{
    public sealed record GetWarehouseItemsByWarehouseQuery : IRequest<IEnumerable<GetWarehouseItemsByWarehouseQueryResult>>
    {
        #region Properties
        public Guid WarehouseId { get; init; }
        #endregion
    }
}
