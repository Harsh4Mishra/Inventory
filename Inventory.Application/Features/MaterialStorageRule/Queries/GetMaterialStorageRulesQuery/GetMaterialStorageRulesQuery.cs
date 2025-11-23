using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRulesQuery
{
    public sealed record GetMaterialStorageRulesQuery : IRequest<IEnumerable<GetMaterialStorageRulesQueryResult>>
    {
    }
}
