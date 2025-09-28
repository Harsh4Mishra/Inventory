using MediatR;

namespace Inventory.Application.Features.EnumType.Commands.CreateEnumTypeCommand
{
    public class CreateEnumTypeCommand : IRequest<Guid>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        #endregion
    }
}
