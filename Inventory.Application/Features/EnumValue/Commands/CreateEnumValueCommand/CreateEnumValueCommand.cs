using MediatR;

namespace Inventory.Application.Features.EnumValue.Commands.CreateEnumValueCommand
{
    public class CreateEnumValueCommand : IRequest<Guid>
    {
        #region Properties
        public Guid EnumTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        #endregion
    }
}
