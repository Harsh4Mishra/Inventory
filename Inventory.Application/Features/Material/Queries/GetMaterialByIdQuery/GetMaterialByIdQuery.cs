using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Queries.GetMaterialByIdQuery
{
    public sealed record GetMaterialByIdQuery : IRequest<GetMaterialByIdQueryResult>
    {
        #region Properties
        public int Id { get; init; }
        #endregion
    }
}
