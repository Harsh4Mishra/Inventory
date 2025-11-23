using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByIdQuery
{
    public sealed record GetMaterialStorageRuleByIdQuery : IRequest<GetMaterialStorageRuleByIdQueryResult?>
    {
        #region Properties
        public Guid Id { get; init; }
        #endregion
    }
}
