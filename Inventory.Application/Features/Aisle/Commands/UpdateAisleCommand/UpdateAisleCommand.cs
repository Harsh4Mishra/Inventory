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

        public int Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public int StorageSectionId { get; set; }
        public int StorageTypeId { get; set; }
        public int InventoryTypeId { get; set; }

        #endregion
    }
}
