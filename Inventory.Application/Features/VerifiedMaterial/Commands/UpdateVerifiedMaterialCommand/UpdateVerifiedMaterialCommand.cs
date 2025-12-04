using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.UpdateVerifiedMaterialCommand
{
    public sealed record UpdateVerifiedMaterialCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; }
        public bool? IsQualified { get; set; }
        public string? Reason { get; set; }
        public int? EmpId { get; set; }
        public JsonDocument? Specification { get; set; }

        #endregion
    }
}
