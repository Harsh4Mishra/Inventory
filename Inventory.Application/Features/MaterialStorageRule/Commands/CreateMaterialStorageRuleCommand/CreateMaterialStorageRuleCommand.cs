using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.CreateMaterialStorageRuleCommand
{
    public sealed record CreateMaterialStorageRuleCommand : IRequest<int>
    {
        #region Properties
        public int MaterialId { get; set; }
        public decimal MinQuantity { get; set; }
        public decimal ThresholdQuantity { get; set; }
        public int PreferredSectionId { get; set; }
        #endregion
    }
}
