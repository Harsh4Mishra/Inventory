using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Commands.CreateBomCategoryCommand
{
    public sealed record CreateBomCategoryCommand : IRequest<Guid>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        #endregion
    }
}
