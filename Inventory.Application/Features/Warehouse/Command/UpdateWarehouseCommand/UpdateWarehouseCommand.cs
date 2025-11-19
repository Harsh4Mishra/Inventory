using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Command.UpdateWarehouseCommand
{
    public sealed record UpdateWarehouseCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public JsonDocument? Address { get; set; }

        #endregion
    }
}
