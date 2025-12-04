using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByMaterialIdQuery
{
    public sealed record GetMaterialStorageRuleByMaterialIdQuery : IRequest<GetMaterialStorageRuleByMaterialIdQueryResult?>
    {
        #region Properties
        public int MaterialId { get; init; }
        #endregion
    }
}
