
using MediatR;

namespace Inventory.Application.Features.EnumType.Commands.DeleteEnumTypeCommand
{
    public class DeleteEnumTypeCommand : IRequest<Unit>
    {
        #region Properties

        public int? Id { get; set; }

        #endregion
    }
}
