using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByProductIdQuery
{
    public sealed record GetAllocationsByProductIdQuery : IRequest<IEnumerable<GetAllocationsByProductIdQueryResult>>
    {
        #region Properties
        public int ProductId { get; init; }

        #endregion
    }
}
