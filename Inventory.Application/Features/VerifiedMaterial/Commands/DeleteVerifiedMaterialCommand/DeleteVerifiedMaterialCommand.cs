using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.DeleteVerifiedMaterialCommand
{
    public class DeleteVerifiedMaterialCommand : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }

        #endregion
    }
}
