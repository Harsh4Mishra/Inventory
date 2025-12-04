using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialByIdQuery
{
    public sealed record GetVerifiedMaterialByIdQuery : IRequest<GetVerifiedMaterialByIdQueryResult?>
    {
        public int Id { get; init; }
    }
}
