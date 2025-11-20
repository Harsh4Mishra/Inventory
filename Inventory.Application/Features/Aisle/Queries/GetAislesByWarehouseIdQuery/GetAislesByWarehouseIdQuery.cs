using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Queries.GetAislesByWarehouseIdQuery
{
    public sealed record GetAislesByWarehouseIdQuery
         : IRequest<IEnumerable<GetAislesByWarehouseIdQueryResult>>
    {
        #region Properties

        public Guid WarehouseId { get; init; } = default;

        #endregion
    }
}
