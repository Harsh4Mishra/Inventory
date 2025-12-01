using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Queries.GetAllocationByIdQuery
{
    public sealed record GetAllocationByIdQuery : IRequest<GetAllocationByIdQueryResult?>
    {
        #region Properties
        public Guid Id { get; init; }

        #endregion
    }
}
