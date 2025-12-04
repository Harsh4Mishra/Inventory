using MediatR;

namespace Inventory.Application.Features.EnumValue.Commands.DeleteEnumValueCommand
{
    public class DeleteEnumValueCommand : IRequest<Unit>
    {
        #region Properties

        public int EnumTypeId { get; init; }
        public int Id { get; init; }

        #endregion
    }
}
