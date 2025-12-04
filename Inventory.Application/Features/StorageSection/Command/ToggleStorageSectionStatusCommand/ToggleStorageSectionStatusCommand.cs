using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.ToggleStorageSectionStatusCommand
{
    public sealed record ToggleStorageSectionStatusCommand : IRequest<Unit>
    {
        #region Properties

        public int Id { get; init; }
        public bool IsActive { get; init; }

        #endregion
    }
}
