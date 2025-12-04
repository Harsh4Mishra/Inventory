using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.UpdateStorageSectionCommand
{
    public sealed record UpdateStorageSectionCommand
        : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public string? TemperatureRange { get; set; }
        public string? Description { get; set; }

        #endregion
    }
}
