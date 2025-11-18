using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Queries.GetVendorByIdQuery
{
    public sealed record GetVendorByIdQuery : IRequest<GetVendorByIdQueryResult>
    {
        #region Properties
        public Guid Id { get; init; }
        #endregion
    }
}
