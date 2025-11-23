using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.UpdateMaterialStorageRuleCommand
{
    public sealed record UpdateMaterialStorageRuleCommand : IRequest<Unit>
    {
        #region Properties
        public Guid Id { get; set; } = default;
        public decimal MinQuantity { get; set; }
        public decimal ThresholdQuantity { get; set; }
        public Guid PreferredSectionId { get; set; }
        #endregion
    }
}
