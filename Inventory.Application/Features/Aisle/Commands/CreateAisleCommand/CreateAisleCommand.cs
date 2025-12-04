using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Commands.CreateAisleCommand
{
    public sealed record CreateAisleCommand
        : IRequest<int>
    {
        #region Properties

        public string Name { get; init; } = default!;
        public int WarehouseId { get; init; }
        public int StorageSectionId { get; init; }
        public int StorageTypeId { get; init; }
        public int InventoryTypeId { get; init; }

        #endregion
    }
}
