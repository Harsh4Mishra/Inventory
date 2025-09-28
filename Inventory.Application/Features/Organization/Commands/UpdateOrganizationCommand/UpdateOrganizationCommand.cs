using MediatR;

namespace Inventory.Application.Features.Organization.Commands.UpdateOrganizationCommand
{
    public class UpdateOrganizationCommand : IRequest<Unit>
    {
        #region properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public string? Description { get; set; }

        #endregion
    }
}
