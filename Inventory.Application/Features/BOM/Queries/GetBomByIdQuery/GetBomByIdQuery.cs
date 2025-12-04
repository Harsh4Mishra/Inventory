using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Queries.GetBomByIdQuery
{
    public sealed record GetBomByIdQuery : IRequest<GetBomByIdQueryResult?>
    {
        #region Properties
        public int Id { get; init; }
        #endregion
    }
}
