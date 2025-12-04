using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Queries.GetStorageSectionByIdQuery
{
    public sealed record GetStorageSectionByIdQuery : IRequest<GetStorageSectionByIdQueryResult?>
    {
        public int Id { get; init; }
    }
}
