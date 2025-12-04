using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsByEmpIdQuery
{
    public sealed record GetVerifiedMaterialsByEmpIdQuery : IRequest<IEnumerable<GetVerifiedMaterialsByEmpIdQueryResult>>
    {
        public int EmpId { get; init; }
    }
}
