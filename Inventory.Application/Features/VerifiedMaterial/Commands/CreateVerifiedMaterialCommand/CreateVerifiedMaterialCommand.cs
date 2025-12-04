using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.CreateVerifiedMaterialCommand
{
    public sealed record CreateVerifiedMaterialCommand : IRequest<int>
    {
        #region Properties
        public int MaterialBatchId { get; set; }
        public decimal Quantity { get; set; }
        public int? EmpId { get; set; }
        public string? Specification { get; set; }
        public bool? IsQualified { get; set; }
        public string? Reason { get; set; }

        #endregion
    }
}
