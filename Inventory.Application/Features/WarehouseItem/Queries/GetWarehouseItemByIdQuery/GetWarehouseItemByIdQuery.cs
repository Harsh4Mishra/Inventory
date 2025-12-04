using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemByIdQuery
{
    public sealed record GetWarehouseItemByIdQuery : IRequest<GetWarehouseItemByIdQueryResult?>
    {
        #region Properties
        public int Id { get; init; }
        #endregion
    }
}
