using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Commands.DeleteBomItemCommand
{
    public class DeleteBomItemCommand : IRequest<Unit>
    {
        #region Properties
        public Guid Id { get; set; }
        #endregion
    }
}
