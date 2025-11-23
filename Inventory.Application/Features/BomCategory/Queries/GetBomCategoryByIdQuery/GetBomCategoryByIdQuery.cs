using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Queries.GetBomCategoryByIdQuery
{
    public sealed record GetBomCategoryByIdQuery : IRequest<GetBomCategoryByIdQueryResult?>
    {
        #region Properties
        public Guid Id { get; init; }
        #endregion
    }
}
