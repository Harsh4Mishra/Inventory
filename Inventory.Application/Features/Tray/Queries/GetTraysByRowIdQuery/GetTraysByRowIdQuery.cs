using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Queries.GetTraysByRowIdQuery
{
    public sealed record GetTraysByRowIdQuery
        : IRequest<IEnumerable<GetTraysByRowIdQueryResult>>
    {
        #region Properties

        public int RowId { get; init; } = default;

        #endregion
    }
}
