using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Queries.GetTrayByIdQuery
{
    public sealed record GetTrayByIdQuery
        : IRequest<GetTrayByIdQueryResult>
    {
        #region Properties

        public Guid Id { get; init; } = default;

        #endregion
    }
}
