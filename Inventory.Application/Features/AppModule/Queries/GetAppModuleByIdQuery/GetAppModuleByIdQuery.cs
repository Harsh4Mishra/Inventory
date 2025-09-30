using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.AppModule.Queries.GetAppModuleByIdQuery
{
    public sealed record GetAppModuleByIdQuery : IRequest<GetAppModuleByIdQueryResult?>
    {
        #region Properties
        public Guid Id { get; init; }
        #endregion
    }
}
