using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Queries.GetStorageSectionsQuery
{
    public sealed record GetStorageSectionsQuery : IRequest<IEnumerable<GetStorageSectionsQueryResult>>
    {
    }
}
