using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Queries.GetActiveStorageSectionsQuery
{
    public sealed record GetActiveStorageSectionsQuery : IRequest<IEnumerable<GetActiveStorageSectionsQueryResult>>
    {
    }
}
