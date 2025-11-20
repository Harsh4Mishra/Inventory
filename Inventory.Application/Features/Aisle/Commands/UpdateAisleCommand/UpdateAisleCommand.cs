using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Commands.UpdateAisleCommand
{
    public sealed record UpdateAisleCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public Guid StorageSectionId { get; set; }
        public Guid StorageTypeId { get; set; }
        public Guid InventoryTypeId { get; set; }

        #endregion
    }
}
