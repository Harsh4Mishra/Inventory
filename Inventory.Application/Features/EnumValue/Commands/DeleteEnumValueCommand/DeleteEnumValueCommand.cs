using MediatR;

namespace Inventory.Application.Features.EnumValue.Commands.DeleteEnumValueCommand
{
    public class DeleteEnumValueCommand : IRequest<Unit>
    {
        #region Properties

        public Guid EnumTypeId { get; init; }
        public Guid Id { get; init; }

        #endregion
    }
}
