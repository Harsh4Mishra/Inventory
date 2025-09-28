using MediatR;

namespace Inventory.Application.Features.Organization.Commands.ToggleOrganizationStatusCommand
{
    public sealed class ToggleOrganizationStatusCommand
        : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; init; }
        public bool IsActive { get; init; }

        #endregion
    }
}
