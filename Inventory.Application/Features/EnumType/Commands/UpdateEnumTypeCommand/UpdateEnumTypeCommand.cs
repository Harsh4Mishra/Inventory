using MediatR;

namespace Inventory.Application.Features.EnumType.Commands.UpdateEnumTypeCommand
{
    public class UpdateEnumTypeCommand : IRequest<Unit>
    {
        #region properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        #endregion
    }
}
