using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.UpdateMaterialBatchQuantityCommand
{
    public sealed record UpdateMaterialBatchQuantityCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; } = default;
        public decimal NewQuantity { get; set; }
        #endregion
    }
}
