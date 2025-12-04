using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRulesByPreferredSectionQuery
{
    public sealed record GetMaterialStorageRulesByPreferredSectionQuery : IRequest<IEnumerable<GetMaterialStorageRulesByPreferredSectionQueryResult>>
    {
        #region Properties
        public int PreferredSectionId { get; init; }
        #endregion
    }
}
