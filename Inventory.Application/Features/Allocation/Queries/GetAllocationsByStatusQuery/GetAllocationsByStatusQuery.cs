using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationsByStatusQuery
{
    public sealed record GetAllocationsByStatusQuery : IRequest<IEnumerable<GetAllocationsByStatusQueryResult>>
    {
        #region Properties
        public string Status { get; init; } = default!; // "allocated", "picked", "shipped", "released", "cancelled"

        #endregion
    }
}
