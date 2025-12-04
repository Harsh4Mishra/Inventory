using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByOrderIdQuery
{
    public sealed record GetAllocationsByOrderIdQuery : IRequest<IEnumerable<GetAllocationsByOrderIdQueryResult>>
    {
        #region Properties
        public int OrderId { get; init; }

        #endregion
    }
}
