using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.CreateMaterialStorageRuleCommand
{
    public sealed record CreateMaterialStorageRuleCommand : IRequest<Guid>
    {
        #region Properties
        public Guid MaterialId { get; set; }
        public decimal MinQuantity { get; set; }
        public decimal ThresholdQuantity { get; set; }
        public Guid PreferredSectionId { get; set; }
        #endregion
    }
}
