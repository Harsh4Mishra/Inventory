using MediatR;

namespace Inventory.Application.Features.Organization.Commands.DeleteOrganizationCommand
{
    public class DeleteOrganizationCommand : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }

        #endregion
    }
}
