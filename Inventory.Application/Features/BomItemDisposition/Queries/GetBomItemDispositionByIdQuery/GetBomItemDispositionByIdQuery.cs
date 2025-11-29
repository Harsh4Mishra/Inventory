using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionByIdQuery
{
    public sealed record GetBomItemDispositionByIdQuery : IRequest<GetBomItemDispositionsByIdQueryResult>
    {
        public Guid Id { get; init; }
    }
}
