using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Command.CreateWarehouseCommand
{
    public sealed record CreateWarehouseCommand : IRequest<Guid>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public JsonDocument? Address { get; set; }

        #endregion
    }
}
