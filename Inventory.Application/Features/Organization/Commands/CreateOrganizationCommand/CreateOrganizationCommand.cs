using MediatR;

namespace Inventory.Application.Features.Organization.Commands.CreateOrganizationCommand
{
    public sealed record CreateOrganizationCommand
        : IRequest<int>
    {
        #region Properties

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        #endregion
    }
}
