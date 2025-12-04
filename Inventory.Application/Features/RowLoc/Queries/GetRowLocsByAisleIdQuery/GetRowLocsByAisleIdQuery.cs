using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Queries.GetRowLocsByAisleIdQuery
{
    public sealed record GetRowLocsByAisleIdQuery
        : IRequest<IEnumerable<GetRowLocsByAisleIdQueryResult>>
    {
        #region Properties

        public int AisleId { get; init; } = default;

        #endregion
    }
}
