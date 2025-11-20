using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Commands.CreateAisleCommand
{
    public sealed record CreateAisleCommand
        : IRequest<Guid>
    {
        #region Properties

        public string Name { get; init; } = default!;
        public Guid WarehouseId { get; init; }
        public Guid StorageSectionId { get; init; }
        public Guid StorageTypeId { get; init; }
        public Guid InventoryTypeId { get; init; }

        #endregion
    }
}
