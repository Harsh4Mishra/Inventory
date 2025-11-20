using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Queries.GetStorageSectionByNameQuery
{
    public sealed record GetStorageSectionByNameQuery : IRequest<GetStorageSectionByNameQueryResult?>
    {
        public string Name { get; init; } = default!;
    }
}
