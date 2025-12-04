using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Queries.GetRowLocByIdQuery
{
    public sealed record GetRowLocByIdQuery
        : IRequest<GetRowLocByIdQueryResult>
    {
        #region Properties

        public int Id { get; init; } = default;

        #endregion
    }
}
