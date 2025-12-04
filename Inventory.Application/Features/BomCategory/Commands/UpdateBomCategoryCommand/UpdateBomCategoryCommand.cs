using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Commands.UpdateBomCategoryCommand
{
    public sealed record UpdateBomCategoryCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; } = default;
        public string Name { get; set; } = default!;
        #endregion
    }
}
