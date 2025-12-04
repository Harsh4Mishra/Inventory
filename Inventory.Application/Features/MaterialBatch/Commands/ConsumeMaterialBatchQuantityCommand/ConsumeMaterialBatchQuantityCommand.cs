using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.ConsumeMaterialBatchQuantityCommand
{
    public sealed record ConsumeMaterialBatchQuantityCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; } = default;
        public decimal ConsumedQuantity { get; set; }
        #endregion
    }
}
