using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.DeleteMaterialStorageRuleCommand
{
    public class DeleteMaterialStorageRuleCommand : IRequest<Unit>
    {
        #region Properties
        public int Id { get; set; }
        #endregion
    }
}
