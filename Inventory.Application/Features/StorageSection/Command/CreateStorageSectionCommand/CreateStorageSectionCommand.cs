using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.CreateStorageSectionCommand
{
    public sealed record CreateStorageSectionCommand : IRequest<int>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string? TemperatureRange { get; set; }
        public string? Description { get; set; }

        #endregion
    }
}
